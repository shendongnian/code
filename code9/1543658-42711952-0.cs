    public class Test
    {
        // Ok, we declare the hashtable here. It could be a Dictionary though, so we don't have to cast it. But you requested a hashtable.
        private Hashtable hash = new Hashtable();
        public Test()
        {
        }
        // We declare the signature of the methods that we will store. This means that we accept any methods which receive two decimal parameters and return a decimal output
        private delegate decimal Calculation(decimal x, decimal y);
        public void Run()
        {
            // A sample implementation of the delegate
            Calculation sum = (decimal x, decimal y) =>
            {
                return x + y;
            };
            // Another sample implementation
            Calculation minus = (decimal x, decimal y) =>
            {
                return x - y;
            };
            // Here we add both of them to the hashtable
            this.hash.Add("Sum", sum);
            this.hash.Add("Minus", minus);
            // Now ask the user for input values
            Console.Write("X: ");
            var xInput = decimal.Parse(Console.ReadLine());
            Console.Write("Y: ");
            var yInput = decimal.Parse(Console.ReadLine());
            // Ask the user which method to execute
            Console.WriteLine("1. Sum");
            Console.WriteLine("2. Minus");
            Console.Write("> ");
            var choice = int.Parse(Console.ReadLine());
            // Get the selected method from the hashtable
            Calculation calc;
            if (choice == 1)
            {
                calc = (Calculation)this.hash["Sum"];
            }
            else if (choice == 2)
            {
                calc = (Calculation)this.hash["Minus"];
            }
            else
            {
                throw new Exception();
            }
            // execute it, and output the result
            Console.WriteLine(calc(xInput, yInput));
            Console.ReadKey();
        }
    }
