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
                {'title':'�������� � �����������', 'description':'����� � ������� ������ � ����� ����� � �� ������ �����', 'icon':'bi bi-stopwatch'},
                {'title':'������������ ��������', 'description':'������������ ������� � ��������� �� �����', 'icon':'bi bi-eye'},
                {'title':'�����������������', 'description':'��������� ����������� � ��������� ������ �� ������������ ��� �������', 'icon':'bi bi-info-circle'},
                {'title':'��������� �������������', 'description':'���� ������� ������ ������ ������ � �������� �� ���� �������', 'icon':'bi bi-person-arms-up'},
                {'title':'����������� �����', 'description':'������������������ ����� ������ ��������� ���������� ������ ��� ������, ������� �� �����', 'icon':'bi bi-search'},
                {'title':'��������������������', 'description':'���� ����������� ��� �� � ��� ��������� ����������', 'icon':'bi bi-browser-chrome'}
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
