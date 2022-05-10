using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Data;
using WebApplication2.Data.Entities;
using WebApplication2.Services;

namespace WebApplication2.Pages
{
    public class PollsEditModel : PageModel
    {
        public Poll Poll { get; set; }

        private readonly IPollService _service;

        public PollsEditModel(IPollService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Poll = await _service.GetPollByIdAsync(id);
            return Page();
        }

        public IActionResult OnPost(Answer answer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //WTF?
            answer.Id = 0;

            _service.AddAnswer(answer);

            return Redirect($"/polls/{answer.PollId}");
        }
    }
}