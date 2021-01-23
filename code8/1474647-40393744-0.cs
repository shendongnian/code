    public static void Main(string[] args)
    {
    Start:
        Console.WriteLine("Please Input the Grade");
        char grade = Convert.ToChar(Console.ReadLine());
        switch (grade)
        {
            case 'A':
            case 'a':
                Console.WriteLine("Excellent Work!");
                break;
            case 'B':
            case 'b':
                Console.WriteLine("Very Good Effort! Just a couple of     Errors =)");
                break;
            case 'C':
            case 'c':
                Console.WriteLine("You Passed. Push Yourself Next Time");
                break;
            case 'D':
            case 'd':
                Console.WriteLine("Better put in more effort next time. I know you can do better");
                break;
            default:
                Console.WriteLine("Invalid Grade.");
                break;
        }
        Console.ReadKey();
        goto Start;
    }
