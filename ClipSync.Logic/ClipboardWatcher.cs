using System.Runtime.InteropServices;

namespace ClipSync.Logic
{
    public class ClipboardWatcher : Form
    {
        //Static instance of this form class
        private static ClipboardWatcher instance;

        //Need to dispose this form
        private static IntPtr nextClipboardViewer;

        public delegate void OnClipboardChangeEventHandler(ClipboardFormat format, object data);

        public static event OnClipboardChangeEventHandler OnClipboardChange;

        //Start listening for clipboard change
        public static void Start()
        {
            //to prevent creation of multiple instance of this class
            if (instance != null)
            {
                return;
            }

            var thread = new Thread(new ParameterizedThreadStart(x => Application.Run(new ClipboardWatcher())));
            thread.SetApartmentState(ApartmentState.STA); // give the [STAThread] attribute
            thread.Start();
        }

        //Stop listening

        public static void Stop()
        {
            instance.Invoke(new MethodInvoker(() =>
            {
                ChangeClipboardChain(instance.Handle, nextClipboardViewer);
            }));

            instance.Invoke(new MethodInvoker(instance.Close));
            instance.Dispose();
            instance = null;
        }

        protected override void SetVisibleCore(bool value)
        {
            CreateHandle();

            instance = this;

            nextClipboardViewer = SetClipboardViewer(instance.Handle);

            base.SetVisibleCore(false);
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        // defined in winuser.h this are the message that we listen to
        private const int WM_DRAWCLIPBOARD = 0x308;

        private const int WM_CHANGECBCHAIN = 0x030D;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    ClipChanged();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
            base.WndProc(ref m);
        }

        static readonly string[] formats = Enum.GetNames(typeof(ClipboardFormat));

        private void ClipChanged()
        {
            IDataObject iData = Clipboard.GetDataObject();

            ClipboardFormat? format = null;

            foreach (var f in formats)
            {
                if (iData.GetDataPresent(f))
                {
                    format = (ClipboardFormat)Enum.Parse(typeof(ClipboardFormat), f);
                    break;
                }
            }

            object data = iData.GetData(format.ToString());

            if (data == null || format == null)
                return;

            if (OnClipboardChange != null)
                OnClipboardChange((ClipboardFormat)format, data);
        }
    }
}