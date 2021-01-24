    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication49
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                string SelectedClient = "";
                List<RateRepository> raterepository = new List<RateRepository>();
                Dictionary<string, decimal> SelectedClientRates = raterepository.Where(c => c.Client == SelectedClient)
                    .GroupBy(x => x.ItemName, y => y.Rate)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
        public class RateRepository
        {
            public string Client { get; set; }
            public string ItemName { get; set; }
            public decimal Rate { get; set; }
        }
       
    }
