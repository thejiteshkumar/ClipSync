namespace ClipSync.Logic
{
    public static class SampleList
    {
        public static List<ClipModel> PopulateClipsList()
        {
            List<ClipModel> clipModels = new();

            int maxClipEntiries = 10;

            for (int i = 0; i < maxClipEntiries; i++)
            {
                clipModels.Add(new ClipModel
                {
                    Id = Guid.NewGuid().ToString(),
                    CopiedText = $"This is my copied text {i}",
                    CreatedOn = DateTime.Now.ToString()
                });
            }

            return clipModels;
        }
    }

    public class ClipModel
    {
        public string? Id { get; set; }
        public string? CopiedText { get; set; }
        public string? CreatedOn { get; set; }
    }
}