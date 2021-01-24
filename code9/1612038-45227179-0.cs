    class Program
    {
            static void Main(string[] args)
            {
                 Init();
            }
            public static void Init()
            {
                 AskUserInput();
            }
            public static string stops()
            {
                 string stop = Console.ReadLine();
                 //here i get the user input
                 Console.WriteLine(stop);
                 return stop;
            }
            public static void AskUserInput()
            {
                 string stop = stops();
                 Console.WriteLine("i need this:" + stop);                 
            }
     }
