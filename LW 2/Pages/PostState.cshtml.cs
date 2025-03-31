using LW_2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LW_2.Pages
{
    public class PostStateModel(StateRepository stateRepository) : PageModel
    {
        public StateRepository StateRepository = stateRepository;

        [BindProperty]
        public State? State { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (State != null) await StateRepository.AddAsync(State);
            return RedirectToPage();
        }
    }
}
