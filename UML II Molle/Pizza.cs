﻿using System;
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
        public DietType Diet => _Recipe.Diet;
        public double Price;
        public Recipe _Recipe;


        public Pizza(string name, double price, Recipe recipe)
        {
            PizzaName = name;
            _Recipe = recipe;
            Price = price;
        }

        public void EditPizza(string newName)
        {
            PizzaName = newName;
        }

        public void EditPizza(int newPrice)
        {
            Price = newPrice;
        }

        public void AddIngredients(List<Ingredient> ingredientsToAdd)
        {
            foreach (Ingredient ingredient in ingredientsToAdd)
            {
                _Recipe.Ingredients.Add(ingredient);
            }
        }
        public void RemoveIngredients(List<Ingredient> ingredientsToRemove)
        {
            foreach (Ingredient ingredient in ingredientsToRemove)
            {
                _Recipe.Ingredients.Remove(ingredient);
            }
        }



        public string FurtherDetails()
        {

            if (_Recipe != null)
            {
                string d = string.Empty;
                foreach (Ingredient i in _Recipe.Ingredients)
                {
                    d += i.Name;
                    if (i.Name.Length < 8) { d += "\t"; }

                    if (!i.VeganComp && !i.VegetarianComp) { d += "\t-\n"; }
                    else if (i.VegetarianComp && !i.VeganComp) { d += "\tVegetarian\n"; }
                    else if (i.VeganComp) { d += "\tVegan\n"; }
                    else { d += "\tcant get ingredient dietinfo\n"; }
                }
                return d;
            }
            else return "Can't fetch recipe for" + this.PizzaName;
        }

        public override string ToString()
        {
            return $"{PizzaName}, {Price} DKK ({Diet}).";
        }
    }
}
