using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_II_Molle
{
    public class Ingredient
    {
        public string Name { get; set; }
        public bool VeganComp;
        public bool VegetarianComp;
        public List<Ingredient> IngredientRepo = new List<Ingredient>();

        public Ingredient(string name, bool vgComp, bool vComp)
        {
            Name = name;
            VegetarianComp = vComp;
            VeganComp = vgComp;
            IngredientRepo.Add(this);
        }

        public override string ToString()
        {
            string diet;
            if (VegetarianComp && !VeganComp) { diet = "Vegetarian"; }
            else if (!VegetarianComp && VeganComp) { diet = "Vegan"; }
            else { diet = "Standard"; }

            return $"{Name}, {diet}";
        }
    }
}
