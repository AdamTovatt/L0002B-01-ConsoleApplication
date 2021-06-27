using System;
using System.Collections.Generic;

namespace ChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeCalculator calculator = new ChangeCalculator(CurrencyLoader.Load("SEK"));

            while (true)
            {
                int price = TakePositiveIntInput("Ange pris:");
                int payed = TakePositiveIntInput("Ange betalad mängd:");

                while(payed < price)
                {
                    Console.WriteLine("Du måste betala minst så mycket det kostar");
                    payed = TakePositiveIntInput("Ange betalad mängd:");
                }

                Dictionary<Denomination, int> change = calculator.GetChange(payed - price);

                Console.WriteLine(new string('-', 10));
                Console.WriteLine(change.Keys.Count > 0 ? "Din växel:" : "Det blev ingen växel");

                foreach (Denomination denomination in change.Keys)
                {
                    Console.WriteLine(string.Format("{0} {1}", change[denomination], change[denomination] > 1 ? denomination.PluralName : denomination.SingularName)); //lägger till text för att visa växeln. Om det är fler än 1 av en valör tar vi pluralversionen av namnet, annars singularversionen
                }

                Console.WriteLine(new string('-', 10));
                Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static int TakePositiveIntInput(string message)
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
