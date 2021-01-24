    public class Test
    {
        // Ok, we declare the hashtable here. It could be a Dictionary though, so we don't have to
        // cast it. But you requested a hashtable.
        private Hashtable hash = new Hashtable();
		
		// Were it a dictionary, we'd have:
		// private Dictionary<string, Calculation> dict = new Dictionary<string, Calculation>();
        // We declare the signature of the methods that we will store. This means that we accept any
        // methods which receive two decimal parameters and return a decimal output
        private delegate decimal Calculation(decimal x, decimal y);
        public Test()
        {
        }
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
            this.hash.Add("+", sum);
            this.hash.Add("-", minus);
			
			// Were it a dictionary, we'd have:
			// this.dict.Add("+", sum);
			// this.dict.Add("+", minus);
			
			// Note that in the hashtable you can put ANYTHING. Were it a dictionary, it would be strong-typed and
			// we'd be able to only add Calculation types
            // Now ask the user for input values
            Console.Write("X: ");
            var xInput = decimal.Parse(Console.ReadLine());
            Console.Write("Y: ");
            var yInput = decimal.Parse(Console.ReadLine());
            // Ask the user which method to execute
            Console.WriteLine("Which method to execute? Enter number:");
            Console.WriteLine("1. +");
            Console.WriteLine("2. -");
            Console.Write("> ");
            var choice = int.Parse(Console.ReadLine());
            // Get the selected method from the hashtable
            Calculation calc;
            if (choice == 1)
            {
                calc = (Calculation)this.hash["+"];
            }
            else if (choice == 2)
            {
                calc = (Calculation)this.hash["-"];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
			
			// Were it a dictionary, we'd have (note that we don't have to cast it):
			// calc = this.dict["-"];
            // execute it, and output the result
            Console.WriteLine("Result: " + calc(xInput, yInput));
            Console.ReadKey();
        }
    }
