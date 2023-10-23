namespace ClipSync.Logic
{
    public interface IClipboardManager
    {
        Task GetClipBoardDetail();
        Task SetClipBoardDetail();
    }
}