using System.IO;
using System.Linq;
using System.Reflection;

namespace ChangeCalculator
{
    public static class CurrencyLoader //statisk klass för att ladda valutor
    {
        public static Currency Load(string currencyName) //laddar en valuta baserat på en valutas namn
        {
            Assembly assembly = Assembly.GetExecutingAssembly(); //hämtar en referens till den nuvarande assemblyn som innehåller valutafilen som en embedded resource
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(string.Format("{0}.json", currencyName))); //hittar namet för valutafilen genom att matcha de tillgängliga filernamnens slut med namnet på valutan från parametern

            using (Stream stream = assembly.GetManifestResourceStream(resourceName)) //gör en ström till den filen vi vill läsa
            using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8)) //skapar en streamreader som läser strömmen. Har satt den till att explicit använda utf8 encoding även om det egentligen inte borde behövas om filen är utf8
            {
                return Currency.FromJson(reader.ReadToEnd()); //läser filen och deserialiserar den json som lästs till ett currencyobjekt. Viktigt att filen är sparad med utf8 encoding, annars fungerar inte åäö osv
            } //självklart använder vi ett using statement så att inte strömmen fastnar i minnet
        }
    }
}
