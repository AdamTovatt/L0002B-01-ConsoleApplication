using Newtonsoft.Json;

namespace ChangeCalculator
{
    public class Denomination //klass för en valör, använder newtonsoft.json
    {
        [JsonProperty("currencyAmount")] //jsonproperty säger vad fältet ska heta i json, användbart eftersom json och c# har olika regler för stora och små bokstäver
        public decimal CurrencyAmount { get; set; } //hur mycket en valör är värd

        [JsonProperty("singularName")]
        public string SingularName { get; set; } //det "människovänliga" namnet i singular

        [JsonProperty("pluralName")]
        public string PluralName { get; set; } //det "människovänliga" namnet i plural
    }
}
