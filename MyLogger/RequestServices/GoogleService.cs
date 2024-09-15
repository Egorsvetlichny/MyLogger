using MyLogger.RequestServices.Interfaces;

namespace MyLogger.RequestServices
{
    public class GoogleService : IRequestService
    {
        public async Task<string> GetPage()
        {
            var url = $"https://www.google.com/";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Google API error: {response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
