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
