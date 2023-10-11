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

        public string SearchMenu(string input)
        {
            string r = string.Empty;
            var results = MenuPizzas.Where(pizza => pizza.PizzaName.ToLower().Contains(input.ToLower()));
            if (results.Count() > 0)
            {
                foreach (var pizza in results)
                {
                    r += pizza.ToString() + "\n";
                }
            }
            return "Name matches:\n" + r;
        }

        

        

        public List<Pizza> AllPizzas
        {
            get { return MenuPizzas; }
        }
    }
}
