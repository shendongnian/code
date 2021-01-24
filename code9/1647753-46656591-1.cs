    class Program
    {
        static void Main(string[] args)
        {
    
            int number = GetNumberToSquareFromUser();
            int result = SquareValue(number);
    
            Console.WriteLine("{0} squared is " + result, number);
            Console.ReadKey();
        }
    
        public static int SquareValue(int numberToSquare)
        {
            return numberToSquare * numberToSquare;
        }
    
        public static int GetNumberToSquareFromUser()
        {
            Console.WriteLine("Please enter a number to square: ");
            int NumberToSquare = int.Parse(Console.ReadLine());
            return NumberToSquare;
        }
    
    }
