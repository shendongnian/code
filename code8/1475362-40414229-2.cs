        //examples
        class Program
        {
            static void Main(string[] args)
            {
                //Your original example
                var items = new List<int> { 0, 1, 5, 7 };
                var gap = items.FindFirstGap();
                Console.WriteLine(gap); //shows 2
    
                //No gaps
                items = new List<int> { 0, 1, 2, 3 };
                gap = items.FindFirstGap();
                Console.WriteLine(gap); //shows 4
    
                //no 0
                items = new List<int> { 1, 2, 3, 4 };
                gap = items.FindFirstGap();
                Console.WriteLine(gap); //shows 0
                Console.ReadLine();
            }
        }
