    public void Main()
                {
                    string sJSON = "{\"StudentInformation\": {\"rollNumber\": null,\"isClassLeader\": false,\"result\": \"Pass\"},\"CollegeInformation\": {\"allClass\": [\"A\", \"B\"],\"currencyAccepted\": \"INR\",\"calendarDates\": [],\"currencyCode\": \"INR\",\"collegeCode\": null,\"hasBulidingFundPrices\": false,\"hasHostel\": false,\"hasSecurityFares\": false},\"Collegetrips\": [{\"tripsdate\": [{\"departureTripDate\": \"2017-08-15 00:00:00\",\"Places\": [{\"destination\": \"Bombay\",\"price\": [{\"priceAmount\": 1726}]}]}]}]}";
                    Rootobject obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(sJSON);
                    Price price = obj.Collegetrips.Select(ct =>
                    {
                        var r = ct.tripsdate.Select(td =>
                        {
                            var r1 = td.Places.Select(p =>
                            {
                                Price itemPrice = p.price.FirstOrDefault();
                                return itemPrice;
                            }).FirstOrDefault();
        
                            return r1;
        
                        }).FirstOrDefault();
                        return r;
                    }).FirstOrDefault();
        
                    if (price != null)
                        Console.Write(price.priceAmount);
                    else
                        Console.Write("Not Found!");
        
        
                }
    
    
        public class Rootobject
        {
            public Studentinformation StudentInformation { get; set; }
            public Collegeinformation CollegeInformation { get; set; }
            public Collegetrip[] Collegetrips { get; set; }
        }
        
        public class Studentinformation
        {
            public object rollNumber { get; set; }
            public bool isClassLeader { get; set; }
            public string result { get; set; }
        }
        
        public class Collegeinformation
        {
            public string[] allClass { get; set; }
            public string currencyAccepted { get; set; }
            public object[] calendarDates { get; set; }
            public string currencyCode { get; set; }
            public object collegeCode { get; set; }
            public bool hasBulidingFundPrices { get; set; }
            public bool hasHostel { get; set; }
            public bool hasSecurityFares { get; set; }
        }
        
        public class Collegetrip
        {
            public Tripsdate[] tripsdate { get; set; }
        }
        
        public class Tripsdate
        {
            public string departureTripDate { get; set; }
            public Place[] Places { get; set; }
        }
        
        public class Place
        {
            public string destination { get; set; }
            public Price[] price { get; set; }
        }
        
        public class Price
        {
            public int priceAmount { get; set; }
        }
