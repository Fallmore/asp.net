using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LW_2.Pages
{
    public class StatesModel : PageModel
    {
        private readonly ILogger<StatesModel> _logger;

        public StatesModel(ILogger<StatesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
