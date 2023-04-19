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

        //https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1
        public async Task<List<CardShuffle>> GetShuffledCards(int count)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"new/shuffle/?deck_count={count}");
         // dynamic  List<CardShuffle> cards = await response.Content.ReadAsAsync<List<CardShuffle>>();
            var result = await response.Content.ReadAsStringAsync();
            List<CardShuffle> cards = JsonConvert.DeserializeObject<List<CardShuffle>>(result);
            
            // Console.WriteLine( result );

            return cards;
            
        }
    }
}
