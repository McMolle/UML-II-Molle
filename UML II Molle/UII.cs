using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UML_II_Molle
{
    public static class UII
    {
        private static Menu? _menu;
        private static Recipe? _ingredients;

        public static void CacheMenu(Menu menu)
        {
            _menu = menu;
        }

        public static void CacheIngredientRepo(Recipe recipe)
        {
            _ingredients = recipe;
        }

        public static void StartScreen()
        {
            Header();
            Console.WriteLine("\n(1). Show Menu\n(2). Search Menu\n(3). Create new Pizza\n(4). Edit existing Pizza\n(5). Show all Pizzas in the system");
            Footer();
            string? inp = Console.ReadLine();
            if (inp != null)
            {
                switch (inp)
                {
                    case "1":
                        {
                            PrintMenu();
                        }
                        break;
                    case "2":
                        {
                            Header();
                            SearchMenu();
                        }
                        break;
                    case "3":
                        CreatePizza();
                        break;
                    case "4":
                        //EditExistingPizza
                        break;
                    case "5":
                        //ShowAllPizzasInSystem
                        break;
                    default:
                        Console.WriteLine("-");
                        break;

                }
            }
        }

        public static void PrintMenu()
        {
            Header();
            Console.WriteLine("Menu: ");
            if (_menu != null) {
                List<Pizza> pizzas = _menu.AllPizzas;


                for (int i = 0; i < pizzas.Count; i++) {
                    Console.WriteLine($"{i}. {pizzas[i]}");

                }
                Console.WriteLine("\n\n(1). Return to main menu\n(2). Edit existing Pizza \n(3). Create new Pizza\n(4). Expand details");
                Footer();

                var inp = Console.ReadLine();
                if (inp != null) {
                    switch (inp) {
                        case "1":
                            StartScreen();
                            break;
                        case "2":
                            //Edit pizza
                            break;
                        case "3":
                            break;
                        case "4":
                            Header();
                            foreach (Pizza p in _menu.AllPizzas) {
                                Console.WriteLine($"{p}\nIngredients\n{p.FurtherDetails()}\n\n");
                            }
                            Footer();
                            break;
                        default:
                            break;
                    }
                }

            }
            else { CustomError("Menu:", "Can't show menu - Menu is null."); }
        }

        public static void SearchMenu()
        {
            Console.WriteLine("Search Menu:\n");
            var inp = Console.ReadLine();
            string results = string.Empty;
            if (inp != null)
            {
                if (_menu != null)
                {
                    results = _menu.SearchMenu(inp);
                }
                else { CustomError("Menu:", "Can't search in menu - Menu is null."); }
            }
            else CustomError("Search Menu:", "Input is null.");

            if (results != string.Empty)
            {
                SearchedMenuResults(results);
            }
            else
            {
                Console.WriteLine("No search results.");
                Footer();
                SearchMenu();
            }
        }

        public static void SearchedMenuResults(string r)
        {
            Header();
            Console.WriteLine(r);
            Footer();
        }

        public static void CreatePizza()
        {
            Header();
            Console.WriteLine("Creating new pizza; Type in all ingredients to add to pizza:");
            Console.WriteLine("Ingredients:");
            if (_ingredients != null)
            {
                List<Ingredient> tIngr = new List<Ingredient>();


                for (int i = 0; i < _ingredients.Ingredients.Count; i++)
                {
                    Console.WriteLine($"{i}:\t{_ingredients.Ingredients[i]}");
                }
                Footer();
                var inp = Console.ReadLine();
                if (inp != null)
                {
                    foreach (char c in inp)
                    {
                        if (_ingredients.Ingredients[c] != null)
                        {
                            tIngr.Add(_ingredients.Ingredients[c]);
                        }
                    }
                    CreatePizzaTwo(tIngr);
                }
            }
        }


        public static void CreatePizzaTwo(List<Ingredient> ingrAdded)
        {
            string tName;
            int tPrice;
            int parser;
            Header();
            Console.WriteLine("Your pizza:");
            if (ingrAdded != null)
            {
                foreach (Ingredient ing in ingrAdded)
                {
                    Console.WriteLine($"({ingrAdded.IndexOf(ing)}). {ing}");
                }
            }
            Footer();
            Console.WriteLine("Name this pizza:");
            var pni = Console.ReadLine();
            if (pni != null)
            {
                tName = pni;
            }
            Console.WriteLine("Set the price:");
            var pnp = Console.ReadLine();
            if (pnp != null)
            {
                if (Int32.TryParse(pnp, out parser))
                {
                    tPrice = parser;
                }
                else Console.WriteLine("Invalid Price");
            }

            else
            {
                Console.WriteLine("No ingredients in system.");
                Footer();
            }
        }

        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("================================");
        }

        public static void Header(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("================================");
        }

        public static void Footer()
        {
            Console.WriteLine("\n================================");
            //Console.WriteLine("            _....._\r");
            //Console.WriteLine("        _.:`.--|--.`:._\r");
            //Console.WriteLine("      .: .'\\o  | o /'. '.\r");
            //Console.WriteLine("     // '.  \\ o|  /  o '.\\\r");
            //Console.WriteLine("    //'._o'. \\ |o/ o_.-'o\\\\\r");
            //Console.WriteLine("    || o '-.'.\\|/.-' o   ||\r");
            //Console.WriteLine("    ||--o--o-->|<--o--o--\r");
            //Console.WriteLine("      ________ ___,,,,,,,\r");
            //Console.WriteLine("     [________>__________\\\r");
            //Console.WriteLine("      ________   .===-\r");
            //Console.WriteLine("     [________>c((_==-\r");
            //Console.WriteLine("                 '===-\r");
            //Console.WriteLine("Input:");
        }



        public static void CustomError(string obj, string details)
        {
            Header();
            Console.WriteLine($"\n!! {obj} {details} !!");
            Footer();
        }
    }
}
