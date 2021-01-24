    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
				
    public class Program
    {
	    public void Main()
        {
			var result = @"{
			""base"": ""EUR"",
			""date"": ""2017-06-30"",
			""rates"": {
				""AUD"": 1.4851,
				""BGN"": 1.9558,
				""BRL"": 3.76,
				""CAD"": 1.4785
			}}";
				
		    var values = (ExchangeRates) JsonConvert.DeserializeObject<TempExchangeRates>(result);
		
		
		    Console.WriteLine(values.Base);
		    Console.WriteLine(values.Date);
		
		    foreach(var rate in values.Rates)
			    Console.WriteLine(rate.Name + ": " + rate.
        }
    }
    public class TempExchangeRates
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string,decimal> Rates { get; set; }
		public static explicit operator ExchangeRates(TempExchangeRates tmpRates)
        {
		    var xRate = new ExchangeRates();
		
			xRate.Base = tmpRates.Base;
			xRate.Date = tmpRates.Date;
			xRate.Rates = new List<Rates>();
			
		    foreach(var de in tmpRates.Rates)
			    xRate.Rates.Add(new Rates{Name = de.Key, Value = de.Value});
		
		    return xRate;
	    }
    }
    public class ExchangeRates
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public IList<Rates> Rates { get; set; }
    }
    public class Rates
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
