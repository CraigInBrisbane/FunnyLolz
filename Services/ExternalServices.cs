using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services
{

    internal static class ExternalServices
    {
        public static async Task<string> GetJoke(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.StatusCode);
            var json = await response.Content.ReadAsStringAsync();
            var joke = JsonConvert.DeserializeObject<JokeResponse>(json);

            return joke.Joke;
        }

        private class JokeResponse
        {
            public string Id { get; set; }
            public string Joke { get; set; }
            public string Status { get; set; }
        }
    }


}
