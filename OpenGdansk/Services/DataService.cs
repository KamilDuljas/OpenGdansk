using OpenGdansk.Model.Ztm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenGdansk.Services
{
    public class DataService
    {
        private readonly HttpClient _httpClient;

        public DataService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
        }

        public async Task<Header> GetHeaderAsync(string url)
        {
              var response = await _httpClient.GetStringAsync(url);
            return response == null
                ? throw new InvalidOperationException("Response from GetHeaderAsync is null!")
                : JsonSerializer.Deserialize<Header>(response)!;
        }

    }
}
