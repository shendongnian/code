    class Program
    {
        static void Main(string[] args)
        {
            int amountOfNumbers;
            int counter = 0;
            int randomNumbers = 0;
            int calcRandomNumbers=0;
            Random generateRandNums = new Random();
            Console.WriteLine(generateRandNums.Next(5, 29));
            Console.WriteLine("\nHow many numbers do you want to be entered?");
            amountOfNumbers = Convert.ToInt32(Console.ReadLine());
            while (counter < amountOfNumbers)
            {
                counter++;
                randomNumbers = generateRandNums.Next(20);
                Console.Write(randomNumbers + ", ");
                calcRandomNumbers = +randomNumbers;
            }
            Console.WriteLine("The final sum is " + calcRandomNumbers);
            Console.ReadKey();
        }
    }
