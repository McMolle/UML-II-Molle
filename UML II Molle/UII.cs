using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_II_Molle
{
    public static class UII
    {
        private static Menu _menu;

        public static void CacheMenu(Menu menu)
        {
            _menu = menu;
        }

        public static void StartScreen()
        {
            Console.WriteLine("BIG MOMMA PIZZARIA\n(1). Show Menu\n(2). Search Menu\n(3). Create new Pizza\n(4). Edit existing Pizza\n(5). Show all Pizzas in the system");
            string? inp = Console.ReadLine();
            if (inp != null)
            {
                switch (inp)
                {
                    case "1":
                        PrintMenu(_menu.AllPizzas); 
                        break;


                }
            }
        }

        public static void PrintMenu(List<Pizza> pizzas)
        {
            Console.WriteLine("Menu: ");

            for (int i = 0; i < pizzas.Count; i++)
            {
                Console.WriteLine($"{i}. {pizzas[i]}");

            }
        }

        public static void SearchedMenuResults()
        {

        }


        public static void CustomError(string obj, string details)
        {
            Console.WriteLine($"\n!! {obj} {details} !!");
        }
    }
}
