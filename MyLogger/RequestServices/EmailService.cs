using MyLogger.RequestServices.Interfaces;

namespace MyLogger.RequestServices
{
    public class EmailService : IRequestService
    {
        public async Task<string> GetPage()
        {
            var url = $"https://mailf.ru";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Email API error: {response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
