﻿using WebApplication2.Data;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services
{
    public interface IPollService
    {
        Task AddAnswer(Answer answer);
        Task AddPoll(Poll poll);
        Task DeleteAnswer(Answer answer);
        Task DeletePoll(Poll poll);
        Task<List<Poll>> GetPollAsync();
        Task<Poll> GetPollByIdAsync(int id);
        Task UpdateAnswer(Answer answer);
        Task UpdatePoll(Poll poll);
        Task Vote(Vote vote);
    }
}