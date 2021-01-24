    namespace Calculations
    {
        public class Program
        {
            private static List<Calculations> calcs = new List<Calculations>();
    
            public static void Main(string[] args)
            {
                Console.WriteLine("In this program you will put 10 different prices and a value will be returned.");
                Console.WriteLine();
                for (int i = 0; i < 10; ++i)
                {
                    Console.Write("Enter a price: ");
                    Calculations calc = new Calculations(int.Parse(Console.ReadLine()));
                    calc.GetPrice();
                    calcs.Add(calc); //This is for example if you want to modify or re-access them
                }
            }
        }
    
        public class Calculations
        {
            private static Calculations instance;
            private static int _total;
    
            private static int total
            {
                get
                {
                    return _total;
                }
                set
                {
                    instance.actsubtotal = value;
                    _total += value; //The single value will be summed to a stored absolute total.
                    instance.acttotal = _total;
                }
            }
            
            //actsubtotal: Is the actual subtotal you entered.
            //acttotal: Is the total that was stored in each case, if you enter for example:
            //--- 30, 20, 50, you will have 3 instances, and the value of each acttotal will be: 30, 50, 100
            public int actsubtotal,
                       acttotal;
    
            public Calculations(int subtotal)
            {
                instance = this; //There is the magic, with this, you will tell the property where to find the last value.
                total = subtotal; //Pass it as a single value (without summing it) 
            }
    
            public void GetPrice()
            {
                Console.WriteLine("-------------");
                Console.WriteLine();
                Console.WriteLine("You actually entered: {0}", actsubtotal);
                Console.WriteLine("Your current total is: {0}", total);
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }
    }
