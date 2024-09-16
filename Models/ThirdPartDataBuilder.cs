using Newtonsoft.Json;

namespace MyWebAPI.Models
{
    public class ThirdPartDataBuilder
    {
        private readonly HttpClient _httpClient;

        public ThirdPartDataBuilder(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> GetDataFromAPI(string url)
        {

            string resp = await _httpClient.GetStringAsync(url);

            return resp;

        }

    }
}
