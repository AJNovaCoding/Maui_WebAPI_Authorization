using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiLoginAuth.Models;
using System.Net.Http.Json;


namespace MauiLoginAuth.DataAccess
{
    public class ItemDataAccess
    {
        private readonly HttpClient client;

        public ItemDataAccess()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:33426/"); // Replaced with API base URL
        }

        //Save an item to the Web API
        public async Task<bool> SaveItemAsync(Item item)
        {
            var response = await client.PostAsJsonAsync("api/Items", item);
            return response.IsSuccessStatusCode;
        }

        //Retieve all items from the Web API
        public async Task<List<Item>> GetItems()
        {
            var items = await client.GetFromJsonAsync<List<Item>>("api/Items");
            return items ?? new List<Item>();
        }

    }
}
