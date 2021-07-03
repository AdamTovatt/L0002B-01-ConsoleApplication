//Adam Tovatt 9909189335    L0002B
using System;
using System.Collections.Generic;

namespace ChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeCalculator calculator = new ChangeCalculator(CurrencyLoader.Load("SEK")); //skapar en ny instans av ChangeCalculator med valutan SEK som laddas in via CurrencyLoader från valutans konfigurationsfil

            while (true)
            {
                int price = TakePositiveIntInput("Ange pris:");
                int payed = TakePositiveIntInput("Ange betalad mängd:");

                while(payed < price) //man måste betala minst så mycket det kostar
                {
                    Console.WriteLine("Du måste betala minst så mycket det kostar");
                    payed = TakePositiveIntInput("Ange betalad mängd:");
                }

                Dictionary<Denomination, int> change = calculator.GetChange(payed - price); //räknar ut växeln

                Console.WriteLine(new string('-', 10)); //skriver ut en rad så det ska vara snyggt bara
                Console.WriteLine(change.Keys.Count > 0 ? "Din växel:" : "Det blev ingen växel"); //skriver ut ett medelande baserat på om det fanns någon växel eller inte

                foreach (Denomination denomination in change.Keys) //går igen eventuella valörer som blev i växel för att skriva ut dem
                {
                    Console.WriteLine(string.Format("{0} {1}", change[denomination], change[denomination] > 1 ? denomination.PluralName : denomination.SingularName)); //lägger till text för att visa växeln. Om det är fler än 1 av en valör tar vi pluralversionen av namnet, annars singularversionen
                }

                Console.WriteLine(new string('-', 10));
                Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static int TakePositiveIntInput(string message) //metod för att ta input i form av ett positivt heltal
        {
            Console.WriteLine(message);

            int result;

            while(!int.TryParse(Console.ReadLine(), out result) || result < 0)
            {
                Console.WriteLine("Var god ange ett positivt heltal:");
            }

            return result;
        }
    }
}
