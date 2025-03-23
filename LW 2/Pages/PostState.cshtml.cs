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

        public IActionResult OnPost()
        {
            if (State != null) StateRepository.Add(State);
            return RedirectToPage();
        }
    }
}
