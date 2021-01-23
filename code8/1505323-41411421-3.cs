    static void Main(string[] args)
        {
            Random rand = new Random();
            do
            {
                Write("enter a number between 1 and 5");
                string response = Console.ReadLine();
                int x = 5;
                if (Validate(response, "1-5")) int.TryParse(response, out x);                
                Write(rand.Next(0,x));
                Write("Do you want to continue?  Please select yes or no.");                
            } while (Validate(Console.ReadLine().ToLower(), "yes"));
        }
        static void Write(string s) => Console.WriteLine(s);
        static bool Validate(string s, string Pattern) => Regex.Match(s, Pattern).Success; 
