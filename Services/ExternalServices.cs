using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

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

        private class JokesResponse
        {
            public int Current_Page { get; set; }
            public int Limit { get; set; }
            public List<JokeResponse> results { get; set; } = new List<JokeResponse>();
        }

        internal static async Task<List<string>> GetJokes(HttpClient client, string searchTerm, int count)
        {
            var encodedTerm = HttpUtility.UrlEncode(searchTerm);
            HttpResponseMessage response = await client.GetAsync($"search?term={HttpUtility.UrlEncode(searchTerm)}&limit={count}");
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.StatusCode);
            var json = await response.Content.ReadAsStringAsync();
            var joke = JsonConvert.DeserializeObject<JokesResponse>(json);

            return joke.results.Select(x=>x.Joke).ToList();
        }
    }


}
