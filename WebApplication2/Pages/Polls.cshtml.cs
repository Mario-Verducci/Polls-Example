using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Data.Entities;
using WebApplication2.Services;

namespace WebApplication2.Pages
{
    public class PollModel : PageModel
    {
        public Poll Poll { get; set; }

        public List<Poll> Polls { get; set; }

        private readonly IPollService _service;

        public PollModel(IPollService service)
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

            return RedirectToPage("/Polls");
        }
    }

    public class PollViewModel
    {
        public List<string> Answers { get; set; } = new List<string> { "Ja", "Nein" };
    }
}