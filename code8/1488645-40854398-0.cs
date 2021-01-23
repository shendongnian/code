    using System;
    class Program
    {
    static void Main(string[] args)
    {
        int result = 0;
        int U4;
        string T4;
        string statement1 = "How many calls have you taken on this product since your trainin?";
        string statement2 = "Did you experience any problems that your training did not prepa";
        Console.WriteLine("Please type value of T4");
        T4 = Console.ReadLine();
        Console.WriteLine("Please type value of U4");
        U4 = int.Parse(Console.ReadLine());
        if (T4 == statement1)
        {
            result = 6;
        }
        else
        {
            if(T4 == statement2)
            {
                if (U4 == 1)
                {
                    result = 0;
                }
                else
                {
                    result = 6;
                }
            }
            else
            {
                result = 7 - U4;
            }
        }
        Console.WriteLine("result is : "+result);
        Console.ReadLine();
    }
    }
