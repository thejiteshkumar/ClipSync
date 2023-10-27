namespace ClipSync.Logic
{
    public static class ClipMonitor
    {
        public delegate void OnClipboardChangeEventHandler(ClipboardFormat format, object data);

        public static event OnClipboardChangeEventHandler OnClipboardChange;

        public static void Start()
        {
            ClipboardWatcher.Start();
            ClipboardWatcher.OnClipboardChange += (ClipboardFormat format, object data) =>
            {
                if (OnClipboardChange != null)
                    OnClipboardChange(format, data);
            };
        }

    }
}