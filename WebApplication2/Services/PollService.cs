using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services
{
    public class PollService : IPollService
    {
        private readonly PollContext _context;

        public PollService(PollContext context)
        {
            _context = context;
        }

        public async Task<List<Poll>> GetPollAsync()
            => await _context.Polls
            .Include(x => x.Answers)
            .Include(x => x.Votes)
            .ToListAsync();

        public async Task<Poll> GetPollByIdAsync(int id)
            => await _context.Polls
            .Include(x => x.Answers)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddPoll(Poll poll)
        {
            await _context.Polls.AddAsync(poll);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePoll(Poll poll)
        {
            _context.Polls.Update(poll);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePoll(Poll poll)
        {
            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync();
        }

        public async Task AddAnswer(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAnswer(Answer answer)
        {
            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnswer(Answer answer)
        {
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }

        public async Task Vote(Vote vote)
        {
            var prevVote = await _context.Votes.FirstOrDefaultAsync(x => x.UserId == vote.UserId);
            if (prevVote != null)
                _context.Votes.Remove(prevVote);

            await _context.Votes.AddAsync(vote);
            await _context.SaveChangesAsync();
        }
    }
}
