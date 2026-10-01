using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebAPIAuth.Models;

namespace WebAPIAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>();

        //GET: api/Items
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        //POST: api/Items
        [HttpPost]
        public IActionResult Post(Item item)
        {
            items.Add(item);
            return Ok();
        }
    }
}
