using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_II_Molle
{
    public class Pizza
    {
        public string PizzaName;
        public DietType Diet;
        public double Price;
        public Recipe _Recipe;


        public Pizza(string name, double price, Recipe recipe)
        {
            PizzaName = name;
            _Recipe = recipe;
            Diet = recipe.Diet;
            Price = price;
        }        

        public void UpdatePizza()
        {

        }


        public override string ToString()
        {
            return $"{PizzaName}, {Price} DKK ({Diet}).";
        }
    }
}
