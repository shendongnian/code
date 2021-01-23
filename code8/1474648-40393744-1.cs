    public static void Main(string[] args)
    {
        Boolean validInputRead = false;
        Char grade;
        
        while(!validInputRead) 
        {
            validInputRead = true;
            Console.WriteLine("Please Input the Grade");
            grade = Convert.ToChar(Console.Read());
    
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
                    validInputRead = false;
                    break;
            }
            Console.ReadKey();
        }
    }
