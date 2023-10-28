using ClipSync.Logic;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

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

            if (data != null)
            {
                WriteToCSV(data.ToString());
            }
        }

        //Use this to sync across different platforms
        private void WriteToCSV(string copiedText)
        {
            string filePath = GetFilePath();

            var records = GetRecordsForCSV(copiedText);

            bool append = false;
            bool addHeaders = true;
            if (File.Exists(filePath))
            {

                append = true;
                addHeaders = false;
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = addHeaders,
                TrimOptions = TrimOptions.Trim,

            };

            using (var writer = new StreamWriter(filePath, append))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(records);
                writer.Flush();
            }
        }

        private string GetFilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ClipSync.csv");

            //return Path.Combine("D:/CodeFiles/CSVTEST/ClipSync.csv");
        }

        private List<CsvModel> GetRecordsForCSV(string text)
        {
            return new List<CsvModel>()
            {
                new CsvModel
                {
                    Id = Guid.NewGuid().ToString(),
                    CopiedText = text,
                    CreatedAt = DateTime.Now.ToString()
                }
            };
        }
    }
}