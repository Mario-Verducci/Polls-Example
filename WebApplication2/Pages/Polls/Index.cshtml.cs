using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Data.Entities;
using WebApplication2.Services;

namespace WebApplication2.Pages.Polls
{
    public class IndexModel : PageModel
    {
        public Poll Poll { get; set; }

        public List<Poll> Polls { get; set; }

        private readonly IPollService _service;

        public IndexModel(IPollService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Polls = await _service.GetPollAsync();
            return Page();
        }

        public IActionResult OnPost(Poll Poll)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.AddPoll(Poll);

            return RedirectToPage("/Polls/Index");
        }

        public IActionResult OnPostAnswer(int pollid, string answer)
        {
            _service.AddAnswer(new Answer { PollId = pollid, AnswerText = answer });
            return RedirectToPage("/Polls/Index");
        }

        public IActionResult OnPostDeletePoll(int pollId)
        {
            _service.DeletePoll(pollId);
            return RedirectToPage("/Polls/Index");
        }

        public IActionResult OnPostUpdateAnswer(int answerId, string answerText)
        {
            _service.UpdateAnswer(answerId, answerText);
            return RedirectToPage("/Polls/Index");
        }

        public IActionResult OnPostDeleteAnswer(int answerId)
        {
            _service.DeleteAnswer(answerId);
            return RedirectToPage("/Polls/Index");
        }
    }

    public class PollViewModel
    {
        public List<string> Answers { get; set; } = new List<string> { "Ja", "Nein" };
    }
}