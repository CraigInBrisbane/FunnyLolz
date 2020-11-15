using SharedLib.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IJokeService
    {
        Task<DadJokeResponse> GetJoke();
    }
}
