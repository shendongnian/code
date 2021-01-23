        char grade = Convert.ToChar(Console.ReadLine());
        switch (grade.ToUpper())
        {
            case 'A':
                Console.WriteLine("Excellent Work!");
                break;
            case 'B':
                Console.WriteLine("Very Good Effort! Just a couple of     Errors =)");
                break;
            case 'C':
                Console.WriteLine("You Passed. Push Yourself Next Time");
                break;
            case 'D':
                Console.WriteLine("Better put in more effort next time. I know you can do better");
                break;
            default:
                Console.WriteLine("Invalid Grade.");
                break;
        }
