    program static void Main(string[] args)
        {
            WorldMarket con = new WorldMarket();
            con.AddToWorldMarket(new NationBuilder() {
                name = "USA",
                ... 
            }
            Console.WriteLine(con.IsNation("USA"));
        }
    }
