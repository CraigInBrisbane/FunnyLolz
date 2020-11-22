using Services.Interfaces;
using SharedLib.Dtos;
using SharedLib.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class JokeService : IJokeService
    {
        private readonly HttpClient _client;
        public JokeService(HttpClient httpClient)
        {
            _client = httpClient;
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
    }
}
