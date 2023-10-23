namespace ClipSync.Logic
{
    public class ClipBoardManger : IClipboardManager
    {

        public Task GetClipBoardDetail()
        {
            var temp = Clipboard.GetText();

            throw new NotImplementedException();
        }

        public Task SetClipBoardDetail()
        {
            throw new NotImplementedException();
        }
    }
}