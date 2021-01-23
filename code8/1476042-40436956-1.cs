    static void Main(string[] args)
    {
        int age;
        string result;
        Console.WriteLine("Please enter your age!");
        if(!int.TryParse(Console.ReadLine(),out age))
        {
            result = "Invalid Input";
        }
        else if (age >= 18)
        {
            result = "You can drink alcohol!";
        }
        else
        {
            result = "You can't drink alcohol!";
        }
        Console.WriteLine(result);
        Console.ReadKey();
    }
