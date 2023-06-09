﻿using DeckOfCardsApi.Models;
using DeckOfCardsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
               return await DrawCard("new");
               
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                Debug.WriteLine(ex);
                return View();
            }
            
        }

        [HttpPost]

        public async Task<IActionResult> DrawCard(DrawTheCardResponse drawcard)
        {
          
            try
            {
                string deckiddet = "new";
                if (drawcard.remaining == 0)
                {
                    deckiddet = "new";
                }
                else
                {
                    deckiddet = drawcard.deck_id;
                }
                return await DrawCard(deckiddet);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                Debug.WriteLine(ex);
                return View();
            }
        }


        public async Task<IActionResult> DrawCard(string deckid)
        {
            try
            {
                DrawTheCardResponse drawcard = await cardsApiService.GetDrawCardsResponse(deckid);
                return View("DrawCard", drawcard);
                
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