using MyLogger.RequestServices.Interfaces;

namespace MyLogger.RequestServices
{
    public class AmazonService : IRequestService
    {
        public async Task<string> GetPage()
        {
            var url = $"https://www.amazon.com/";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Amazon API error: {response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
