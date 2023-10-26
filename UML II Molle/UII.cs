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

        static string? tempName;
        static int tempPrice;
        static int parser;
        static Dictionary<int, Pizza>? tempPizzaDictionary;

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
            Console.WriteLine("\n(1). Show Menu\n(2). Search Menu\n(3). Create new Pizza\n");
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
                        {
                            CreatePizza();
                        }
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
                Console.WriteLine("\n\n(1). Return to main menu\n(2). Edit Pizza \n(3). Create new Pizza\n(4). Delete a pizza\n(5). Expand details");
                Footer();

                var inp = Console.ReadLine();
                if (inp != null) {
                    switch (inp) {
                        case "1":
                            StartScreen();
                            break;
                        case "2":
                            EditPizza_ChoosePizza();
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            Header();
                            foreach (Pizza p in _menu.AllPizzas) {
                                Console.WriteLine($"{p}\nIngredients\n{p.FurtherDetails()}\n\n");
                            }
                            Footer();
                            InputToReturn();
                            break;
                        default:
                            break;
                    }
                }

            }
            else { CustomError("Menu:", "Can't show menu - Menu is null."); }
        }

        public static void EditPizza_ChoosePizza()
        {
            if (_menu == null) { return; }
            else
            {
                Header();
                tempPizzaDictionary = new Dictionary<int, Pizza>();
                int i = 0;
                foreach (Pizza pizza in _menu.AllPizzas)
                {
                    tempPizzaDictionary.Add(i, pizza );
                    Console.WriteLine($"({i}). {pizza}");
                    i++;
                }
                Footer();
                Console.WriteLine("\nWhat pizza do you wish to edit?");
                var inp = Console.ReadLine();
                if (Int32.TryParse(inp, out parser)) {
                    if (tempPizzaDictionary.ContainsKey(parser))
                    {
                        EditPizza_ChooseProperty(tempPizzaDictionary[parser]);
                    }
                }
            }
        }

        public static void EditPizza_ChooseProperty(Pizza pizzaToEdit)
        {
            Header();
            Console.WriteLine(pizzaToEdit.FurtherDetails());
            Console.WriteLine("\n(1). Change pizza name\n(2). Change pizza price\n(3). Add ingredients\n(4). Remove ingredients");
            Footer();
            var editChoiceInput = Console.ReadLine();
            switch (editChoiceInput)
            {
                case "1":
                    EditPizzaName(pizzaToEdit);
                    break;
                case "2":
                    EditPizzaPrice(pizzaToEdit);
                    break;
                case "3":
                    EditPizza_AddIngredients(pizzaToEdit);
                    break;
                case "4":
                    EditPizza_RemoveIngredients(pizzaToEdit);
                    break;
                default:
                    return;
            }
        }

        public static void EditPizzaName(Pizza pizzaToEdit)
        {
            Header();
            Console.WriteLine(pizzaToEdit.FurtherDetails());
            Footer();
            Console.WriteLine("What do you want to call this pizza?");
            var newNameInp = Console.ReadLine();
            if (newNameInp != null)
            {
                pizzaToEdit.EditPizza(newNameInp);
                StartScreen();
            }
            else
            {
                CustomError("EditPizzaName;", "New name input is null");
            }
        }

        public static void EditPizzaPrice(Pizza pizzaToEdit)
        {
            Header();
            Console.WriteLine(pizzaToEdit.FurtherDetails());
            Footer();
            Console.WriteLine("What do you want this pizza to cost?");
            var newPriceInp = Console.ReadLine();
            if (newPriceInp != null && Int32.TryParse(newPriceInp, out parser))
            {
                pizzaToEdit.EditPizza(parser);
                StartScreen();
            }
            else
            {
                CustomError("EditPizzaPrice;", "New price input is null");
            }
        }

        public static void EditPizza_AddIngredients(Pizza pizzaToEdit)
        {
            Header();
            Console.WriteLine(pizzaToEdit.FurtherDetails());
            Footer();
            Console.WriteLine("What ingredient(s) do you want to add to this pizza?");
            var ingredientsToAdd = Console.ReadLine();

        }

        public static void EditPizza_RemoveIngredients(Pizza pizzaToEdit)
        {

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
            Console.WriteLine("Creating new pizza:");
            Console.WriteLine("Ingredients:");
            if (_ingredients != null)
            {
                for (int i = 0; i < _ingredients.Ingredients.Count; i++)
                {
                    Console.WriteLine($"{i}:\t{_ingredients.Ingredients[i]}");
                }
                Footer();
                Console.WriteLine("Input numbers on ingredients to add.\nSeperate with spaces!");

                List<Ingredient> tIngr = new List<Ingredient>();
                string? inp = Console.ReadLine();
                if (inp != null)
                {
                    string[] inputSplit = inp.Split();
                    int[] inputNumbers = Array.ConvertAll(inputSplit, int.Parse);

                    foreach (int c in inputNumbers)
                    {
                        if (_ingredients.Ingredients[c] != null)
                        {
                            tIngr.Add(_ingredients.Ingredients[c]);
                        }
                    }
                }
                CreatePizza_NamePizza(tIngr);
            }
        }


        public static void CreatePizza_NamePizza(List<Ingredient> ingrAdded)
        {
            
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
            var pizzaNameInput = Console.ReadLine();
            if (pizzaNameInput != null)
            {
                tempName = pizzaNameInput;
            }
            Console.WriteLine("Set the price:");
            var pizzaPriceInput = Console.ReadLine();
            if (pizzaPriceInput != null)
            {
                if (Int32.TryParse(pizzaPriceInput, out parser))
                {
                    tempPrice = parser;
                }
                else Console.WriteLine("Invalid Price");
            }
            else
            {
                CustomError("Create new pizza;", "Price input is null");
                Footer();
            }
            Header();
            Console.WriteLine("New pizza:");
            Console.WriteLine($"Name: {pizzaNameInput}\nPrice: {parser}");
            if (ingrAdded != null)
            {
                foreach (Ingredient ing in ingrAdded)
                {
                    Console.WriteLine($"({ingrAdded.IndexOf(ing)}). {ing.Name}");
                }
            }
            Console.WriteLine("\nConfirm pizza creation?");
            Console.WriteLine("(1). Yes\n(2). No");
            var confirmInput = Console.ReadLine();
            if (confirmInput == "1")
            {
                if (pizzaNameInput != null && ingrAdded != null && tempName != null && _menu != null)
                {
                    Recipe createdRecipe = new Recipe(pizzaNameInput, ingrAdded);
                    Pizza createdPizza = new Pizza(tempName, tempPrice, createdRecipe);
                    _menu.AddPizza(createdPizza);
                    StartScreen();
                }
            }
            else if (confirmInput == "2")
            {
                StartScreen();
            }
            else return;
        }

        public static void ShowAndPickFromIngredientRepo()
        {
            Console.WriteLine("Ingredients:");
            if (_ingredients != null)
            {
                for (int i = 0; i < _ingredients.Ingredients.Count; i++)
                {
                    Console.WriteLine($"{i}:\t{_ingredients.Ingredients[i]}");
                }
                Footer();
                Console.WriteLine("Input numbers on ingredient(s) to add.\nSeperate with spaces!");

                List<Ingredient> tIngr = new List<Ingredient>();
                string? inp = Console.ReadLine();
                if (inp != null)
                {
                    string[] inputSplit = inp.Split();
                    int[] inputNumbers = Array.ConvertAll(inputSplit, int.Parse);

                    foreach (int c in inputNumbers)
                    {
                        if (_ingredients.Ingredients[c] != null)
                        {
                            tIngr.Add(_ingredients.Ingredients[c]);
                        }
                    }
                }
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
            Console.WriteLine("\n================================\n");
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

        public static void InputToReturn()
        {
            Console.WriteLine("ENTER to return to main menu");
            Console.ReadLine();
            StartScreen();
        }

        public static void CustomError(string obj, string details)
        {
            Header();
            Console.WriteLine($"\n!! {obj} {details} !!");
            Footer();
        }



    }
}
