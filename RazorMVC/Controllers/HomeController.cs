using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RazorMVC.Models;
using System.Diagnostics;

namespace RazorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StateContext _stateContext = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/")]
        [Route("/Index")]
        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            string feats = @"[
                {'title':'Удобство и доступность', 'description':'Ищите и читайте статьи в любое время и из любого места', 'icon':'bi bi-stopwatch'},
                {'title':'Прозрачность процесса', 'description':'Отслеживайте авторов и источники их работ', 'icon':'bi bi-eye'},
                {'title':'Информированность', 'description':'Получайте уведомления о появлении статей об интересующей вас области', 'icon':'bi bi-info-circle'},
                {'title':'Поддержка пользователей', 'description':'Наша команда всегда готова помочь и ответить на ваши вопросы', 'icon':'bi bi-person-arms-up'},
                {'title':'Эффективный поиск', 'description':'Многокритериальный поиск статей обеспечит нахождение именно тех статей, которые вы ищете', 'icon':'bi bi-search'},
                {'title':'Кроссплатформенность', 'description':'Сайт адаптирован под ПК и под мобильные устройства', 'icon':'bi bi-browser-chrome'}
            ]";
            ViewData["features"] = JsonConvert.DeserializeObject<Features[]>(feats);
            ViewData["states"] = await _stateContext.States.ToListAsync();

            ViewData["imagesLink"] = new string[] { "../img/mainImage.png", "../img/image2.jpg", "../img/image.jpg", "../img/image3.png" };
            return View();
        }

        [HttpGet("/States")]
        public async Task<IActionResult>States()
        {
            ViewData["states"] = await _stateContext.States.ToListAsync();
            return View();
        }

        [HttpPost("/States"), ActionName("Delete")]
        public async Task<IActionResult> States(Guid IdState)
        {
            State? state = await _stateContext.States.SingleOrDefaultAsync(s => s.IdState == IdState);
            if (state != null)
            {
                _stateContext.States.Remove(state);
                await _stateContext.SaveChangesAsync();
            }
            return RedirectToPage("/PostState");
        }

        [Route("/PostState")]
        public IActionResult PostState()
        {
            return View();
        }

        [HttpPost("/PostState")]
        public async Task<IActionResult> PostState(State state)
        {
            _stateContext.States.Add(state);
            await _stateContext.SaveChangesAsync();
            return RedirectToPage("/PostState");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
