using System.Security.Cryptography.X509Certificates;
using UML_II_Molle;



internal class Program
{
    

    private static void Main(string[] args)
    {
        #region Ingredients
        Ingredient Dough = new Ingredient("Dough", true, true);
        Ingredient Tomatopaste = new Ingredient("Tomato paste", true, true);
        Ingredient Pineapple = new Ingredient("Pineapple", true, true);
        Ingredient SmokedTofu = new Ingredient("Smoked tofu", true, true);
        Ingredient BbqSauce = new Ingredient("Barbeque Sauce", true, true);
        Ingredient Ham = new Ingredient("Ham", false, false);
        Ingredient Cheese1 = new Ingredient("Cheese", false, true);
        Ingredient Cheese2 = new Ingredient("Vegan cheese", true, true);
        #endregion

        #region Ingredient Repository-Recipe
        List<Ingredient> ingrRepo = new List<Ingredient> { Dough, Tomatopaste, Pineapple, SmokedTofu, BbqSauce, Ham, Cheese1, Cheese2 };
        #endregion

        #region Ingredient Lists & Recipes
        List<Ingredient> p1_rl = new List<Ingredient> { Dough, Tomatopaste, Cheese2 };                           //vegan
        List<Ingredient> p2_rl = new List<Ingredient> { Dough, Tomatopaste, Cheese2, Ham, Pineapple };           //non veg
        List<Ingredient> p3_rl = new List<Ingredient> { Dough, Tomatopaste, SmokedTofu, BbqSauce, Cheese2 };     //vegan
        List<Ingredient> p4_rl = new List<Ingredient> { Dough, Tomatopaste, Cheese1, Cheese2 };                  //vegetarian

        Recipe p1_R = new Recipe("p1_R", p1_rl);
        Recipe p2_R = new Recipe("p2_R", p2_rl);
        Recipe p3_R = new Recipe("p3_R", p3_rl);
        Recipe p4_R = new Recipe("p4_R", p4_rl);
        #endregion

        #region Pizzas
        Pizza p1 = new Pizza("Magerita", 49.50, p1_R);
        Pizza p2 = new Pizza("Hawaii", 55.50, p2_R);
        Pizza p3 = new Pizza("BBQ", 65.50, p3_R);
        Pizza p4 = new Pizza("Cheese lover", 65.50, p4_R);
        #endregion

        #region new Menu & AddPizzas
        Menu menu1 = new Menu();
        menu1.AddPizza(p1);
        menu1.AddPizza(p2);
        menu1.AddPizza(p3);
        menu1.AddPizza(p4);
        #endregion

       

        UII.CacheMenu(menu1);
        UII.StartScreen();
    }

   
}




