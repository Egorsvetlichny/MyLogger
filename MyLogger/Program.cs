using System;
using MyLogger.Services;
using MyLogger.LogData;
using System.Linq;

namespace MyLogger
{
    public class ProgramClass
    {
        public static void Main(string[] args)
        {
            FileService fs = new FileService();
            MyLogger<object> logger = new MyLogger<object>(fs);

            logger.Log(LogLevel.Debug, "Лог отладочной информации!");
            logger.Log(LogLevel.Info, "Лог пользовательской информации!");
            logger.Log(LogLevel.Warning, "Лог предупреждающей информации!");
            logger.Log(LogLevel.Error, "Лог информации ошибоках!");
            logger.Log(LogLevel.Critical, "Лог критической информации!");

        }
    }
}