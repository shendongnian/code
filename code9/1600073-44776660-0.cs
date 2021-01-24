    class Program
    {
        static void Main(string[] args)
        {
            // You do not call the method to assign it to the variable, 
            // you point to the method (without parentheses)
            Func<int> answer = GetTheAnswerToEverything;
            // Here you actually call the method
            Console.WriteLine(answer());
            Console.ReadLine();
        }
        // This is the method that you call when you write **add()**
        private static int GetTheAnswerToEverything() => 42;
    }
