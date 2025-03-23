using LW_2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LW_2.Pages
{
    public class StatesModel(StateRepository stateRepository) : PageModel
    {
        public IList<State> StateRepository = stateRepository.GetAll();

        public void OnGet()
        {
        }
    }

}
