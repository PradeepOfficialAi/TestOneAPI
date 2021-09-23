using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestOneAPI.Models;

namespace TestOneAPI.Services
{
    public class PizzaServices
    {
        static List<Pizzas> Pizza { get; }
        static int nextId = 3;
        static PizzaServices()
        {
            Pizza = new List<Pizzas>
            {
                new Pizzas()
                {
                    Id = 1,
                    Name = "Classic Italian",
                    IsGlutenFree = false
                },
                new Pizzas()
                {
                    Id = 2,
                    Name = "Veggie",
                    IsGlutenFree = true
                }
            };
        }

        public static List<Pizzas> GetAll() => Pizza;

        public static Pizzas Get(int id) => Pizza.FirstOrDefault(value => value.Id == id);

        public static void Add(Pizzas pizzas)
        {
            pizzas.Id = nextId++;
            Pizza.Add(pizzas);
        }

        public static void Update(Pizzas pizza)
        {
            var index = Pizza.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizza[index] = pizza;
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizza.Remove(pizza);
        }
    }
}
