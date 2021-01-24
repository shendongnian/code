    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace Deserialize
    {
        public class ProductDto
        {
            public decimal customerprice { get; set; }
            public DateTime timestamp { get; set; }
            public string actiontype { get; set; }
            public string resellerpricecurrencysymbol { get; set; }
            public string resellerpricetwo { get; set; }
            public string isactive { get; set; }
            public string starttime { get; set; }
            public string productkey { get; set; }
            public string creationdt { get; set; }
            public int promoid { get; set; }
            public string serviceprovidersellingcurrency { get; set; }
            public bool istrickleallow { get; set; }
            public decimal resellerpriceone { get; set; }
            public int resellerid { get; set; }
            public decimal barrierprice { get; set; }
            public string period { get; set; }
            public long endtime { get; set; }
            public decimal resellerprice { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var json = "{" + Environment.NewLine +
                    "  \"59\": {" + Environment.NewLine +
                    "    \"customerprice\": \"528.00\"," + Environment.NewLine +
                    "    \"timestamp\": \"2017-02-10 13:59:16.711147+00\"," + Environment.NewLine +
                    "    \"actiontype\": \"addnewdomain\"," + Environment.NewLine +
                    "    \"resellerpricecurrencysymbol\": \"INR\"," + Environment.NewLine +
                    "    \"resellerpricetwo\": \"748.00\"," + Environment.NewLine +
                    "    \"isactive\": \"true\"," + Environment.NewLine +
                    "    \"starttime\": \"1486393372\"," + Environment.NewLine +
                    "    \"productkey\": \"dotjetzt\"," + Environment.NewLine +
                    "    \"creationdt\": \"1486735157\"," + Environment.NewLine +
                    "    \"promoid\": \"13333\"," + Environment.NewLine +
                    "    \"serviceprovidersellingcurrency\": \"INR\"," + Environment.NewLine +
                    "    \"istrickleallow\": \"true\"," + Environment.NewLine +
                    "    \"resellerpriceone\": \"489.50\"," + Environment.NewLine +
                    "    \"resellerid\": \"683272\"," + Environment.NewLine +
                    "    \"barrierprice\": \"680.0\"," + Environment.NewLine +
                    "    \"period\": \"1\"," + Environment.NewLine +
                    "    \"endtime\": \"1491004799\"," + Environment.NewLine +
                    "    \"resellerprice\": \"445.0\" " + Environment.NewLine +
                    "  }," + Environment.NewLine +
                    "  \"58\": {" + Environment.NewLine +
                    "    \"customerprice\": \"302.50\"," + Environment.NewLine +
                    "    \"timestamp\": \"2017-02-10 13:59:16.711147+00\"," + Environment.NewLine +
                    "    \"actiontype\": \"addnewdomain\"," + Environment.NewLine +
                    "    \"resellerpricecurrencysymbol\": \"INR\"," + Environment.NewLine +
                    "    \"resellerpricetwo\": \"451.00\"," + Environment.NewLine +
                    "    \"isactive\": \"true\"," + Environment.NewLine +
                    "    \"starttime\": \"1486393234\"," + Environment.NewLine +
                    "    \"productkey\": \"dotgold\"," + Environment.NewLine +
                    "    \"creationdt\": \"1486735157\"," + Environment.NewLine +
                    "    \"promoid\": \"13332\"," + Environment.NewLine +
                    "    \"serviceprovidersellingcurrency\": \"INR\"," + Environment.NewLine +
                    "    \"istrickleallow\": \"true\"," + Environment.NewLine +
                    "    \"resellerpriceone\": \"264.00\"," + Environment.NewLine +
                    "    \"resellerid\": \"683272\"," + Environment.NewLine +
                    "    \"barrierprice\": \"410.0\"," + Environment.NewLine +
                    "    \"period\": \"1\"," + Environment.NewLine +
                    "    \"endtime\": \"1491004799\"," + Environment.NewLine +
                    "    \"resellerprice\": \"240.0\"" + Environment.NewLine +
                    "  }" + Environment.NewLine +
                    "}";
    
                var values = JsonConvert.DeserializeObject<Dictionary<int, ProductDto>>(json);
    
                foreach (var v in values)
                {
                    var poductId = v.Key;
                    var product = v.Value;
                    Console.WriteLine(poductId + " " + product.resellerpriceone);
                }
            }
        }
    }
