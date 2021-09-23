using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestOneAPI.Models;
using TestOneAPI.Services;

namespace TestOneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }


        [HttpGet]
        public List<Pizzas> Get() => PizzaServices.GetAll();

        [HttpGet("{id}")]
        public Pizzas GetOne(int id)
        {
            var pizza = PizzaServices.Get(id);

            if (pizza == null)
            {
                var pizzaRe = new Pizzas();
                return pizzaRe;
            }
            return pizza;
        }

        [HttpPost] 
        public IActionResult Create(Pizzas pizza)
        {
            PizzaServices.Add(pizza);

            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")] 
        public IActionResult Update(int id, Pizzas pizza)
        {
            if (id != pizza.Id) return BadRequest();

            var inPizza = PizzaServices.Get(id);

            if (inPizza is null)
                return NotFound();
            PizzaServices.Update(pizza);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PizzaServices.Delete(id);
            return NoContent();
        }

    }
}
