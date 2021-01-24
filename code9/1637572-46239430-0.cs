     static void Main(string[] args)
        {
            RootObject configfile = LoadJson();
            foreach (var tResult in configfile.results)
            {
                Console.WriteLine("Coin: " + tResult.Coin);
                Console.WriteLine("Lastprice: " + tResult.LP);
                Console.WriteLine("PBV: " + tResult.PBV);
            }
            Console.ReadLine();
        }
