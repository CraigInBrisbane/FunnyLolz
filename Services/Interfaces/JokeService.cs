﻿using SharedLib.Responses;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IJokeService
    {
        Task<DadJokeResponse> GetJoke();
        Task<DadJokeListResponse> GetJokes(string searchTerm, int count);
    }
}
