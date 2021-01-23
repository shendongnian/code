    static void Main(string[] args)
        {
            do
            {
                Write("enter a number between 1 and 5");
                string response = Console.ReadLine();
                int x = 5;
                if (Read(response, "1-5")) int.TryParse(response, out x);                
                int rr = GetRandom(x);
                Write(rr.ToString());
                Write("Do you want to continue?  Please select yes or no.");                
            } while (Read(Console.ReadLine().ToLower(), "yes"));
        }
        static int GetRandom(int x) => new Random().Next(1, x);
        static void Write(string s) => Console.WriteLine(s);
        static bool Read(string s, string Pattern) => Regex.Match(s, Pattern).Success; 
