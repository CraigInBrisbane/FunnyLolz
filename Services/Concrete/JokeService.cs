using Business;
using Services.Interfaces;
using SharedLib.Dtos;
using SharedLib.Responses;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class JokeService : IJokeService
    {
        private readonly HttpClient _client;
        private readonly ILogic _logic;
        public JokeService(HttpClient httpClient, ILogic logic)
        {
            _client = httpClient;
            _logic = logic;
        }
        public async Task<DadJokeResponse> GetJoke()
        {
            var joke = await ExternalServices.GetJoke(_client);
            return new DadJokeResponse
            {
                Data = new DadJokeDto
                {
                    Joke = joke
                }
            };
        }

        public async Task<DadJokeListResponse> GetJokes(string searchTerm, int count)
        {
            var jokes = await ExternalServices.GetJokes(_client, searchTerm, count);

            // Modify jokes to highlight (Uppercase) the search term

            jokes = jokes.Select(x => _logic.HighlightTerms(x, searchTerm)).ToList();

            var result = new DadJokeListResponse
            {
                SearchTerm = searchTerm,
                Data = jokes.Select(x => new DadJokeDto {
                    Joke = x }).ToList()
            };

            return result;
        }
    }
}
