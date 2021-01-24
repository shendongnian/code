    namespace ConsoleApp13
    {
        class Program
        {
            static void Main(string[] args)
            {
        
                Car crossOver = new Car("BMW", "X4", 2015, "6/23/17");
                Car.ReadData(crossOver);
                Console.ReadLine();
            }
        }
        
        public class Car
        {
            private string make;
            private string model;
            private int year;
            private string whenSold;
        
            public Car(string mk, string mdl, int yr, string sld)
            {
                make = mk;
                model = mdl;
                year = yr;
                whenSold = sld;
            }
            public static void ReadData(Car Car)
            {
                Console.WriteLine("Make: " + Car.make);
                Console.WriteLine("Model: " + Car.model);
                Console.WriteLine("Year: " + Car.year);
                Console.WriteLine("Sold at: " + Car.whenSold);
            }
        }
    }
