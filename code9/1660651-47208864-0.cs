    public RootObject GetData(string value)
            {
                try
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    string jsonString = "{\"Customers\":[{\"Id\":\"ALFKI\",\"CompanyName\":\"Alfreds Futterkiste\",\"ContactName\":\"Maria Anders\",\"ContactTitle\":\"Sales Representative\",\"Address\":\"Obere Str. 57\",\"City\":\"Berlin\",\"PostalCode\":\"12209\",\"Country\":\"Germany\",\"Phone\":\"030-0074321\",\"Fax\":\"030-0076545\"},{\"Id\":\"ANATR\",\"CompanyName\":\"Ana Trujillo Emparedados y helados\",\"ContactName\":\"Ana Trujillo\",\"ContactTitle\":\"Owner\",\"Address\":\"Avda. de la Constitución 2222\",\"City\":\"México D.F.\",\"PostalCode\":\"05021\",\"Country\":\"Mexico\",\"Phone\":\"(5) 555-4729\",\"Fax\":\"(5) 555-3745\"}]}";
                    
                    return new JavaScriptSerializer().Deserialize<RootObject>(jsonString);
                    
                }
                    catch (Exception ex){
                    throw;
                }
            }
    public class Customer
        {
            public string Id { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
        }
    
        public class RootObject
        {
            public List<Customer> Customers { get; set; }
        }
