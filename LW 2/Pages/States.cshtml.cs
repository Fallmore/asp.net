using LW_2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LW_2.Pages
{
    public class StatesModel(StateRepository stateRepository) : PageModel
    {
        public IList<State> StateRepository = stateRepository.GetAllAsync().Result;

        [BindProperty]
        public State? State { get; set; }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (State != null)
                await stateRepository.DeleteAsync(State.Id);
            return RedirectToPage();
        }

    }

}
