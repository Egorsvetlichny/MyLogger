using System;
using System.Text;
using MyLogger.Interfaces;

namespace MyLogger.Services
{
    public class FileService : IFile
    {
        private const string _path = "C:\\Users\\fkhor\\VSProjects\\MyLogger\\MyLogger\\Logs.log";

        public async Task WriteLog(string message, Exception exception = null)
        {
            using (StreamWriter sw = new StreamWriter(_path, true, Encoding.Default))
            {
                await sw.WriteLineAsync(message);
            }
        }

        public async Task ReadLogs()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                Console.WriteLine(await sr.ReadToEndAsync());
            }
        }
    }
}
