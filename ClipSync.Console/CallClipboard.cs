using ClipSync.Logic;

namespace ClipSync.Console
{
    public class CallClipboard
    {
        public void CallClipboardMonitor()
        {
            ClipMonitor.OnClipboardChange += ClipboardMonitor_OnClipboardChange;
            ClipMonitor.Start();
        }

        private void ClipboardMonitor_OnClipboardChange(ClipboardFormat format, object data)
        {
            System.Console.WriteLine(data);
        }
    }
}