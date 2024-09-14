using System;

namespace MyLogger.Interfaces
{
    public interface IFile
    {
        Task WriteLog(string message, Exception exception = null);
        Task ReadLogs();
    }
}
