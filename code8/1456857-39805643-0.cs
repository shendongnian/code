    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Script.Serialization;
    namespace ConsoleApplication16
    {
        class Program
        {
            static void Main(string[] args)
            {
                string customerdata = 
                    "[" +
                        "{" +
                            "\"Status\": 21," +
                            "\"CustomerId\": \"e3633ccb-bbea-465d-9ce6-6c37e9c40e2e\"" +
                        "}," +
                        "{" +
                            "\"Status\": 20," +
                            "\"CustomerId\": \"d02e2970-7c28-41b0-89f3-5276a97e12c9\"" +
                        "}" +
                    "]";
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var r = ser.Deserialize<List<CustomerStatus>>(customerdata);
            }
        }
        public class CustomerStatus
        {
            public int Status { get; set; }
            public string CustomerId { get; set; }
        }
    }
