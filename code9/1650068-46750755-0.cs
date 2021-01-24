        //declare the array
        private static int[] numbers = new int[10];
        static void numbersArray()
        {
            //get user input
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Please enter a number: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
        }
        static void DisplayNumbers()
        {
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }
        static void Main(string[] args)
        {
            numbersArray();
            DisplayNumbers();
        }
