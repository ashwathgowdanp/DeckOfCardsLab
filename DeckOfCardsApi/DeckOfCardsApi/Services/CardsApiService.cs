using DeckOfCardsApi.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace DeckOfCardsApi.Services
{
    public class CardsApiService
    {
        private readonly HttpClient _httpClient;
        public CardsApiService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        
        public async Task<CardShuffle> GetShuffledCards()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"new/");
            CardShuffle cards = await response.Content.ReadAsAsync<CardShuffle>();          

            return cards;
            
        }

        public async Task<DrawTheCardResponse> GetDrawCardsResponse(string deckid)
        {
         

          HttpResponseMessage carddrawresponse = await _httpClient.GetAsync($"{deckid}/draw/?count=5");
          DrawTheCardResponse result = await carddrawresponse.Content.ReadAsAsync<DrawTheCardResponse>();

            return result;

        }
        
    }
}
