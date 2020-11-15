using SharedLib.Dtos;
using System.Collections.Generic;

namespace SharedLib.Responses
{
    public class DadJokeListResponse
    {
        public List<DadJokeDto> Data { get; set; } = new List<DadJokeDto>();
    }
}
