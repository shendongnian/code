    private static void note()
    {
        int i;
            Console.WriteLine("Please enter test result");
            int i= Convert.ToInt32(Console.ReadLine());
            if ( i>=90)
            { 
               Console.WriteLine("note is A");
            }
            else if (i >=80 && i < 90 )
            {
                Console.WriteLine("note is B");
            }
            else if (i >= 70 && i < 80)
            {
                Console.WriteLine("note is C");
            }
            else if (i >= 60 && i < 70)
            {
                Console.WriteLine("note is D");
            }
            else if (i < 60)
            {
                Console.WriteLine("Failure");
            }
            else if (i < 0 || i > 100)
            {
                Console.WriteLine("Enter a value between 0 and 100");
            }
            else if (i == 999)
            { Console.WriteLine("You enterd 999 to stop ");
            }
            Console.Writeline("You're result is:" + i);
       Console.ReadKey();
        }
