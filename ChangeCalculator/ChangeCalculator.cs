using System;
using System.Collections.Generic;

namespace ChangeCalculator
{
    public class ChangeCalculator //växelkalylator med stöd för decimaltal även om det aldrig används i den här uppgiften
    {
        public Currency Currency { get; private set; } //den valutan som den här kalkylatorn ska använda

        public ChangeCalculator(Currency currency) //konstruktorn tar in en valuta som parameter
        {
            Currency = currency;
        }

        public Dictionary<Denomination, int> GetChange(decimal changeValue) //metod för att beräkna växel
        {
            if (changeValue < 0) //detta borde aldrig hända för vi kollar innan  vi ens använder GetChange() men det kan vara bra att ge ett fel som tydligt märks om man skulle glömma att kontrollera i koden som implementerar denna kalkylator
                throw new NotSupportedException("A changeValue below 0 is not allowed");

            Dictionary<Denomination, int> result = new Dictionary<Denomination, int>(); //kommer att användas för att ge växeln användaren ska få. Dictionaryn ser också till att vi inte råkar ha flera av samma valör på något sätt, kan iofs hända ändå eftersom jag antar att den bara jämför refenreser ändå och man kanske skriver in flera av samma valör i valutakonfigurationen som deserialiseras som två olika objekt. Man skulle kunna override:a equals för denominationtypen men känns lite overkill för den här uppgiften

            foreach(Denomination denomination in Currency.Denominations)
            {
                int denominationAmount = (int)Math.Floor(changeValue / denomination.CurrencyAmount); //kollar hur många av en valör som behövs
                changeValue -= denominationAmount * denomination.CurrencyAmount; //subtrahera värdet av det antal som bestämmdes på raden innan av den valör som för närvarande kollas på

                if (denominationAmount > 0) //om det inte blev att några sedlar av den nuvarande valören skulle användas ska vi inte ta med det
                    result.Add(denomination, denominationAmount);
            }

            return result;
        }
    }
}
