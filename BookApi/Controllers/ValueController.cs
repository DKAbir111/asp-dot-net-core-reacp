using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace BookApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string> { "Apple", "Banana" };
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "This value is:" +id;
        }
    }
}

