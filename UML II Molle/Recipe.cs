using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_II_Molle
{
    public enum DietType { Vegan, Vegetarian, NonVegetarian}
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public DietType Diet => CheckDiet();

        public Recipe(string name, List<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }

        public DietType CheckDiet()
        {
            int vgC = 0;
            int vC = 0;
            int nv = 0;
            
            foreach (Ingredient i  in Ingredients)
            {
                if (!i.VeganComp && !i.VegetarianComp) { nv++; } 
                else if (i.VegetarianComp && !i.VeganComp) { vC++; } 
                else if (i.VeganComp) { vgC++; }
            }

            if(vgC + vC + nv == Ingredients.Count)
            {
                if (nv > 0) { return DietType.NonVegetarian; }
                else if (nv == 0)
                {
                    if (vC > 0) { return DietType.Vegetarian; }
                    else if (vgC == Ingredients.Count) { return DietType.Vegan; }
                    else { return DietType.NonVegetarian; }
                }
                else { return DietType.NonVegetarian; }
            }
            else { return DietType.NonVegetarian; }
        }
    }
}
