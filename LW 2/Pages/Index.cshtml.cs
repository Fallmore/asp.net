using LW_2.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LW_2.Pages
{
    class Features
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Icon { get; set; }
    }

    public class IndexModel(StateRepository stateRepository) : PageModel
    {
        public IList<State> StateRepository = stateRepository.GetAll();

        public void OnGet()
        {

        }
    }
}
