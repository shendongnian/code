    static void Main(string[] args)
    {
        Console.WriteLine("Guess the number!");
        Random randomObject = new Random();
        int RandNoumber = randomObject.Next(9999) + 1;
        int enteredNumber = int.Parse(Console.ReadLine());
        if (enteredNumber < RandNoumber)
        {
            Console.WriteLine("Wrong it's higher");
        }
        else if(enteredNumber > RandNoumber)
        {
            Console.WriteLine("Wrong it's lower");
        }
        else
        {
            Console.WriteLine("Good Job!");
        }
    }
