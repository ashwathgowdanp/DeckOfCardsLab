using DeckOfCardsApi.Models;
using DeckOfCardsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly CardsApiService cardsApiService;

        public HomeController(CardsApiService cardsApiService)
        {
            this.cardsApiService = cardsApiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<CardShuffle> result = await cardsApiService.GetShuffledCards(1);
                return View(result);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                Debug.WriteLine(ex);
                return View();
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}