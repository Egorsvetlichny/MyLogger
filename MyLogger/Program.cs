using MyLogger.Services;
using MyLogger.LogData;
using MyLogger.RequestServices;

namespace MyLogger
{
    public class ProgramClass
    {
        public static async Task Main(string[] args)
        {
            FileService fs = new FileService();
            MyLogger<AmazonService> amazonLogger = new MyLogger<AmazonService>(fs);
            amazonLogger.Log(LogLevel.Debug, $"Создан логгер {amazonLogger.GetType().GetGenericTypeDefinition().Name}");

            AmazonService amazonService = new AmazonService();
            amazonLogger.Log(LogLevel.Debug, $"Создан объект {amazonService.GetType()}");
            try
            {
                var content = await amazonService.GetPage();

                amazonLogger.Log(LogLevel.Info, "Запрос на получение страницы выполнен успешно!", 200);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка обращения к сервису {amazonService.GetType()}: {ex.Message}");

                amazonLogger.Log(LogLevel.Error, $"Ошибка обращения к сервису {amazonService.GetType()}", 400, exception: ex);
            }
            //Дальнейшее использование данных с сервиса

            amazonLogger.Log(LogLevel.Warning, "Вы используете слишком много оперативной памяти!", 100);

            amazonLogger.Log(LogLevel.Critical, "Приложение полностью упало!", 500, exception: new OutOfMemoryException());


            EmailService emailService = new EmailService();
            MyLogger<EmailService> emailLogger = new MyLogger<EmailService>(fs);
            emailLogger.Log(LogLevel.Debug, $"Создан логгер {emailLogger.GetType().GetGenericTypeDefinition().Name}");
            emailLogger.Log(LogLevel.Debug, $"Создан объект {emailService.GetType()}");

            try
            {
                var content = await emailService.GetPage();

                emailLogger.Log(LogLevel.Info, "Запрос на получение страницы выполнен успешно!", 200);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка обращения к сервису {emailService.GetType()}: {ex.Message}");

                emailLogger.Log(LogLevel.Error, $"Ошибка обращения к сервису {emailService.GetType()}", 400, exception: ex);
            }

            GoogleService googleService = new GoogleService();
            MyLogger<GoogleService> googleLogger = new MyLogger<GoogleService>(fs);
            googleLogger.Log(LogLevel.Debug, $"Логгер {googleLogger.GetType().GetGenericTypeDefinition().Name} готов к работе!");
            googleLogger.Log(LogLevel.Debug, $"Произошло создание объекта {googleService.GetType()}");

            //Падение критической ошибки при работе с гугл сервисом
            googleLogger.Log(LogLevel.Critical, "Работа приложения полностью остановлена!", 500, exception: new ArgumentException());
        }
    }
}