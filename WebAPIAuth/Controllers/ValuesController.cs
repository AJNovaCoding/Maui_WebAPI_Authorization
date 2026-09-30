using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIAuth.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ValuesController : ControllerBase
        {
            // GET: api/<ValuesController>
            [HttpGet]
            [BasicAuthentication] //Apply the BasicAuthentication attribute to this action method
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }
        }
    
}
