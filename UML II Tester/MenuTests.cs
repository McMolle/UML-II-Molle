namespace UML_II_Tester
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void AddPizzaToMenuTest()
        {
            //arrange
            // lav en menu, opret to pizzaer og put de pizzaer ind. opret en ny pizza som jeg så kan tilføje i næste step

            //act
            // put den nye pizza ind i menuen

            //assert
            // flere muligheder her i guess - 1. tjek om menuen nu indeholder et element mere end den gjorde før, og 2. tjek om menuen indeholder pizzaen jeg oprettede i 'arrange' 
            Assert.AreEqual(numbersBefore + 1, numberAfter);

        }

        [TestMethod]
        public void TestRemovePizzaFromMenu()
        {

        }
    }
}