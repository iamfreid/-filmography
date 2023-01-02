using Filmography.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Filmography.Controllers
{
    [Route("api/crud")] //clear read update delete
    [ApiController]
    public class CrudController : ControllerBase
    {
        //private readonly MovieCatalog _items = new MovieCatalog();

        private MovieCatalog _item;

        public CrudController(MovieCatalog item)
        {
            _item = item;
        }


        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(_item.Get());
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery]string input) // "input" - берем из строки запроса. 
        {
            _item.Add(input);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string stringToUpdate, [FromQuery] string newItem)
        {
            for (int i = 0; i < _item.Items.Count; i++)
            {
                if (_item.Items[i] == stringToUpdate)
                {
                    _item.Items[i] = newItem;
                }
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string stringToDelete)
        {
            _item.Items = _item.Items.Where(w => w != stringToDelete).ToList();
            return Ok();
        }





    }
}
