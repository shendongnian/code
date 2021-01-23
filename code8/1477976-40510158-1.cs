            static void Main(string[] args)
            {
                var rateList = new List<MyRates>()
                {
                    new MyRates {Type = "A", Program = "ABC", Rate = "1.0"},
                    new MyRates {Type = "B", Program = "DEF", Rate = "1.5"},
                    new MyRates {Type = "B", Program = "XYZ", Rate = "2.5"},
                };
    
                var myRoot = new MyRoot { LastUpdated = DateTime.Parse("2016-11-09"), Rates = rateList };
    
                var list = rateList.Where(x => x.Type == "B");
    
                //OR try to create a new object
                myRoot = new MyRoot {LastUpdated = myRoot.LastUpdated, Rates = myRoot.Rates.Where(x => x.Type == "B").ToList() };
    
    
                Console.ReadLine();
            }
