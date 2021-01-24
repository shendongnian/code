    static class Offers
    {
        public static List<Vehicle> itemlist = new List<Vehicle>();
        public static void readfromfile()
        {
            var lines = System.IO.File.ReadAllLines("C:\\Offers.csv");
    
            foreach (string item in lines)
            {
                var values = item.Split(',');
                //need to check which type of vehicle is it
                if(values[2] == "Car")
                {
                    itemlist.Add(new Car()
                    {
                        Name = values[0],
                        Price = int.Parse(values[1]),
                        Horsepower = int.Parse(values[3])
                    });
                }
                else if (values[2]=="Bicycle")
                {
                    itemlist.Add(new Bicycle()
                    {
                        Name = values[0],
                        Price = int.Parse(values[1]),
                        NumberOfPedals= int.Parse(values[3])
                    });
                }
    
            }
        }
    }
