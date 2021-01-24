        static void Main(string[] args)
        {
            // ret API url
            string url = "https://openexchangerates.org/api/latest.json?app_id=4be3cf28d6954df2b87bf1bb7c2ba47b";
            // GET Json data from api & map to CurrencyRates
            var todo =  url.GetJsonFromUrl().FromJson<CurrencyRates>();
            // print result to screen
            todo.PrintDump();
        }
        public class CurrencyRates
        {
            public string Disclaimer { get; set; }
            public string License { get; set; }
            public int TimeStamp { get; set; }
            public string Base { get; set; }
            public Dictionary<string, decimal> Rates { get; set; }
        }
