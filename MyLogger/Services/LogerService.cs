using MyLogger.Interfaces;
using MyLogger.LogData;
using System;

namespace MyLogger.Services
{
    public class MyLogger<T> : ILogger<T>
    {
        private readonly IFile _fileService;
        private readonly string _nameSpace;
        private readonly string _logTime = DateTime.Now.ToLongTimeString();

        public MyLogger(IFile fileService)
        {
            _fileService = fileService;
            _nameSpace = typeof(T).FullName;
        }

        private string GenerateMessage(string message, LogLevel logLevel, int traceId, Exception exception)
        {
            if (exception == null)
            {
                return $"{traceId} | {_logTime} [{logLevel}] {_nameSpace} - {message}";
            }
            else
            {
                return $"{traceId} | {_logTime} [{logLevel}] {_nameSpace} - {message} - {exception}";
            }
        }

        public void Log(LogLevel logLevel, string message, int traceId = 0, Exception exception = null)
        {
            string fullLogMessage = GenerateMessage(message, logLevel, traceId, exception);

            switch (logLevel)
            {
                case LogLevel.Debug:
                    LogDebug(fullLogMessage);
                    break;
                case LogLevel.Info:
                    LogInformation(fullLogMessage);
                    break;
                case LogLevel.Warning:
                    LogWarning(fullLogMessage);
                    break;
                case LogLevel.Error:
                    LogError(exception, message);
                    break;
                case LogLevel.Critical:
                    LogCritical(exception, message);
                    break;
            }
        }

        public void LogDebug(string message)
        {
            _fileService.WriteLog(message);
        }

        public void LogInformation(string message)
        {
            _fileService.WriteLog(message);
        }

        public void LogWarning(string message)
        {
            _fileService.WriteLog(message);
        }
        public void LogError(Exception exception, string message)
        {
            _fileService.WriteLog(message, exception);
        }
        public void LogCritical(Exception exception, string message)
        {
            _fileService.WriteLog(message, exception);
        }
    }
}
