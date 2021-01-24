    namespace GoingShopping
    {
        class Program
        {
            private static int cabbageamount;
            private static int tomatoamount;
            private static int cheeseamount;
            private static int breadamount;
            private static int milkamount;
            private static int onionamount;
            bool isvalid = true;
    
            static void Main(string[] args)
            {
                String cabbage = "1";
                String tomatos = "2";
                String Cheese = "3";
                String bread = "4";
                String milk = "5";
                String onion = "6";
                String done = "7";
                String menu = "1) Cabbage" + System.Environment.NewLine + 
                              "2) Tomatos" + System.Environment.NewLine + 
                              "3) Cheese" + System.Environment.NewLine + 
                              "4) Bread" + System.Environment.NewLine + 
                              "5) Milk" + System.Environment.NewLine + 
                              "6) Onion" + System.Environment.NewLine + 
                              "7) I'm done shopping";
    
                int total = cabbageamount + tomatoamount + cheeseamount + breadamount + milkamount + onionamount;
    
                Console.Write("What you like to purchase ? " + System.Environment.NewLine);
                Console.WriteLine(menu);
                string wishlist = "0";
    
    
                while (wishlist != "7")
                {
                    wishlist = Console.ReadLine().Trim();
                    switch (wishlist)
                    {
                        case "1":
                            Console.WriteLine("How many would you like ? ");
                            string cabbageinput = Console.ReadLine();
                            //int cabbageinput = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(menu);
                            break;
                        case "2":
                            Console.WriteLine("How many would you like ? ");
                            string tomatoinput = Console.ReadLine();
                            Console.WriteLine(menu);
    
                            break;
                        case "3":
                            Console.WriteLine("How many would you like ? ");
                            string cheeseinput = Console.ReadLine();
                            Console.WriteLine(menu);
    
                            break;
                        case "4":
                            Console.WriteLine("How many would you like ? ");
                            string breadinput = Console.ReadLine();
                            Console.WriteLine(menu);
    
                            break;
                        case "5":
                            Console.WriteLine("How many would you like ? ");
                            string milkinput = Console.ReadLine();
                            Console.WriteLine(menu);
    
                            break;
                        case "6":
                            Console.WriteLine("How many would you like ? ");
                            string onioninput = Console.ReadLine();
                            Console.WriteLine(menu);
    
                            break;
                        case "7":
                            Console.WriteLine("You have chosen to buy : " + System.Environment.NewLine);
                            Console.WriteLine(cabbageamount + "X" + "Cabbages" + System.Environment.NewLine,
                                              tomatoamount + "X" + "Tomatos" + System.Environment.NewLine,
                                              cheeseamount + "X" + "Cheese" + System.Environment.NewLine,
                                              breadamount + "X" + "Bread" + System.Environment.NewLine,
                                              milkamount + "X" + "Milk" + System.Environment.NewLine,
                                              onionamount + "X" + "Onions" + System.Environment.NewLine);
                            Console.WriteLine("Giving a total of" + total + "items");
                            break;
                        default:    
                            break;
                    }
                }
    
            }
        }
    }
