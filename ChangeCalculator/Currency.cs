using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ChangeCalculator
{
    public class Currency
    {
        [JsonProperty("denominations")]
        public List<Denomination> Denominations { get; set; } //valörer

        public static Currency FromJson(string json) //deserialiserar json till ett valutaobjekt
        {
            Currency currency = JsonConvert.DeserializeObject<Currency>(json);
            currency.Denominations = currency.Denominations.OrderByDescending(c => c.CurrencyAmount).ToList(); //ser till att listan alltid är sorterad på storleken av valörerna i fallande ordning ifall det skulle vara fel i json
            return currency;
        }

        public string ToJson() //serialiserar ett valutaobjekt till json, används inte i den här uppgiften men tycker den borde finnas i den här klassen
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
