using System;
using System.Text;
using System.IO;
using EarthquakeAPI.Services.Abstract;

namespace EarthquakeAPI.Services
{
    public class FileLogger : ILogger
    {
        private static void CreateIfNotExists(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public void LogError(Exception exception)
        {
            CreateIfNotExists("error.log");
            using (var stream = File.Open("error.log", FileMode.Append))
            {
                var errorMessage = $"{DateTime.Now} - {exception.Message}\n";
                var data = Encoding.UTF8.GetBytes(errorMessage);
                stream.Write(data, 0, data.Length);
            }
        }

        public void LogMessage(string text)
        {
            CreateIfNotExists("info.log");
            using (var stream = File.Open("info.log", FileMode.Append))
            {
                var message = $"{DateTime.Now} - {text}\n";
                var data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
