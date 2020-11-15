using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using SharedLib.Dtos;
using SharedLib.Responses;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly ILogger<JokeController> _logger;
        private readonly IJokeService _jokeService;

        public JokeController(ILogger<JokeController> logger, IJokeService jokeService)
        {
            _logger = logger;
            _jokeService = jokeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetJoke()
        {
            var joke = await _jokeService.GetJoke();
            return Ok(joke);
        }

        [HttpGet]
        [Route("{count:int}")]
        public async Task<IActionResult> GetJokes(int count)
        {
            return Ok(new DadJokeListResponse 
            {
                Data = new List<DadJokeDto>
                {
                    new DadJokeDto
                    {
                        Joke = "First joke..."
                    }
                }
            });
        }

    }
}
