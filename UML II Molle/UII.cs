using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_II_Molle
{
    public static class UII
    {
        private static Menu? _menu;

        public static void CacheMenu(Menu menu)
        {
            _menu = menu;
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
                        if (_menu != null)
                        {
                            PrintMenu();
                        }
                        else { CustomError("Menu:", "Can't show menu - Menu is null."); }
                        break;
                    case "2":
                        if (_menu != null)
                        {
                            SearchMenu();
                        }
                        else { CustomError("Menu:", "Can't search in menu - Menu is null."); }
                        break;
                    case "3":
                        //CreateNewPizza
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
            List<Pizza> pizzas = _menu.AllPizzas;

            for (int i = 0; i < pizzas.Count; i++)
            {
                Console.WriteLine($"{i}. {pizzas[i]}");

            }
            Console.WriteLine("\n\n(1). Return to main menu\n(2). Edit existing Pizza \n(3). Create new Pizza\n(4). Expand details");
            Footer();

            var inp = Console.ReadLine();
            if (inp != null)
            {
                switch (inp)
                {
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
                        foreach (Pizza p in _menu.AllPizzas)
                        {
                            Console.WriteLine($"{p}\nIngredients\n{p.FurtherDetails()}\n\n");
                        }
                        Footer();
                        break;
                    default:
                        break;
                }
            }

        }

        public static void SearchMenu()
        {
            Header();
            Console.WriteLine("Search Menu:\n");
            var inp = Console.ReadLine();
            string results = string.Empty;
            if (inp != null)
            {
                if (_menu != null)
                {
                    results = _menu.SearchMenu(inp);
                }
                else CustomError("Search Menu:", "No menu to search."); 
            }
            else CustomError("Search Menu:", "Invalid search term.");

            if (results != string.Empty)
            {
                SearchedMenuResults(results);
            }
            else CustomError("Search Menu:", "Imput not null, Menu not null, but results = string.empty.");
        }

        public static void SearchedMenuResults(string r)
        {
            Header();
            Console.WriteLine(r);
            Footer();
        }
        public static void BasicSegment(string s)
        {
            Header();
            Console.WriteLine(s);
            Footer();
        }

        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("================================");
        }

        public static void Footer()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("================================");
            Console.WriteLine("                _....._\r");
            Console.WriteLine("            _.:`.--|--.`:._\r");
            Console.WriteLine("          .: .'\\o  | o /'. '.\r");
            Console.WriteLine("         // '.  \\ o|  /  o '.\\\r");
            Console.WriteLine("        //'._o'. \\ |o/ o_.-'o\\\\\r");
            Console.WriteLine("        || o '-.'.\\|/.-' o   ||\r");
            Console.WriteLine("        ||--o--o-->|<--o--o--\r");
            Console.WriteLine("            ________ ___,,,,,,,\r");
            Console.WriteLine("           [________>__________\\\r");
            Console.WriteLine("");
            Console.WriteLine("            ________   .===-\r");
            Console.WriteLine("           [________>c((_==-\r");
            Console.WriteLine("                       '===-\r");

        }

      

        public static void CustomError(string obj, string details)
        {
            Header();
            Console.WriteLine($"\n!! {obj} {details} !!");
            Footer();
        }
    }
}
