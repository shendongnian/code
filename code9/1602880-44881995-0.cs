    class Program
    {
        static void Main(string[] args)
        {
            string jsonInput = @"{""3h"":3}";
            var result = (myJsonObj)JsonConvert.DeserializeObject<myJsonObj>(jsonInput);
            Console.WriteLine(result.MyProperty);
        }
    }
    public class myJsonObj
    {
        [JsonProperty(PropertyName = "3h")]
        public string MyProperty { get; set; }
    }
