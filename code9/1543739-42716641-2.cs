    using WebApplication1.Attributes;
    
    namespace WebApplication1.ActionParameters
    {
        [UniversalValidator]
        public class IndexParameters
        {
            public string EMail { get; set; }
            public string CurrencyIsoCode { get; set; }
        }
    }
