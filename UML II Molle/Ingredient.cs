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


        public Ingredient(string name, bool vgComp, bool vComp)
        {
            Name = name;
            VegetarianComp = vComp;
            VeganComp = vgComp;
        }
    }
}
