    static void Main(string[] args)
    {
        Console.WriteLine("Guess the number!");
        Random randomObject = new Random();
        int RandNoumber = randomObject.Next(9999) + 1;
        int enteredNumber;
        while (true)
        {
            bool parsed = int.TryParse(Console.ReadLine(), out enteredNumber);
            if (parsed)
            {
                if (enteredNumber < RandNoumber) //This is where I got an error msg
                {
                    Console.WriteLine("Wrong it's higher");
                }
                else if (enteredNumber > RandNoumber)
                {
                    Console.WriteLine("Wrong it's lower");
                }
                else
                {
                    Console.WriteLine("Good Job!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number");
            }
        }
    }
