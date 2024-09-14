using System;
using MyLogger.LogData;

namespace MyLogger.Interfaces
{
    public interface ILogger<T>
    {
        void Log(LogLevel logLevel, string message, int traceId = 0, Exception exception = null);

        void LogDebug(string message);
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(Exception exception, string message);
        void LogCritical(Exception exception, string message);
        
    }
}
