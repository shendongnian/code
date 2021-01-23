    using System;
    
    namespace _41002924
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(CarTax.getCarTax(100));
                Console.ReadLine();
            }
        }
    
        public static class CarTax
        {
            public static double emissions { get; set; }
            public static double carTax { get { return getCarTax(emissions); } }
    
            public static double getCarTax(double emissions)
            {
                if (emissions == 0)
                {
                    Console.WriteLine("Car tax is 120");
                    //carTax = 120;
                    return 120;
                }
                else if (emissions >= 1 && emissions <= 80)
                {
                    Console.WriteLine("Car tax is 170");
                    //carTax = 170;
                    return 170;
                }
                else if (emissions >= 81 && emissions <= 100)
                {
                    Console.WriteLine("Car tax is 180");
                    //carTax = 180;
                    return 180;
                }
                else if (emissions >= 101 && emissions <= 110)
                {
                    Console.WriteLine("Car tax is 190");
                    //carTax = 190;
                    return 190;
                }
                else if (emissions >= 111 && emissions <= 120)
                {
                    Console.WriteLine("Car tax is 200");
                    //carTax = 200;
                    return 200;
                }
                else if (emissions >= 121 && emissions <= 130)
                {
                    Console.WriteLine("Car tax is 270");
                    //carTax = 270;
                    return 270;
                }
                else    //Catch invalid input
                {
                    Console.WriteLine("Invalid CO2 emissions");
                    //carTax = -999;
                    return -999;
                }
            }
        }
    }
