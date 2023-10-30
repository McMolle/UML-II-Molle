using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_II_Molle
{
    public class Menu
    {

        public List<Pizza> MenuPizzas = new List<Pizza>();


        public Menu()
        {

        }
        

        public void AddPizza(Pizza px)
        {
            MenuPizzas.Add(px);
        }
        public void RemovePizza(Pizza pizza)
        {
            MenuPizzas.Remove(pizza);
        }

        public string SearchMenu(string input)
        {
            string r = string.Empty;
            var nameResults = MenuPizzas.Where(pizza => pizza.PizzaName.ToLower().Contains(input.ToLower()));
            var dietResults = MenuPizzas.Where(pizza => pizza.Diet.ToString().ToLower().Contains(input.ToLower()));
            if (nameResults.Count() > 0)
            {
                foreach (var pizza in nameResults)
                {
                    r += pizza.ToString() + "\n";
                }
                r = "Name Matches:\n" + r;
            }
            if (dietResults.Count() > 0)
            {
                foreach (var pizza in dietResults)
                {
                    r += pizza.ToString() + "\n";
                }
                r = "Diet Matches:\n" + r;
            }
            return r;
        }

        

        

        public List<Pizza> AllPizzas
        {
            get { return MenuPizzas; }
        }
    }
}
