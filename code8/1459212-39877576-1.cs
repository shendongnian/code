    private static void note()
    {
        int[] i = new int[1];
            Console.WriteLine("Please enter test result");
            i[0]= Convert.ToInt32(Console.ReadLine());
            if ( i[0]>=90)
            { 
               Console.WriteLine("note is A");
            }
            else if (i[0] >=80 && i[0] < 90 )
            {
                Console.WriteLine("note is B");
            }
            else if (i[0] >= 70 && i[0] < 80)
            {
                Console.WriteLine("note is C");
            }
            else if (i[0] >= 60 && i[0] < 70)
            {
                Console.WriteLine("note is D");
            }
            else if (i[0] < 60)
            {
                Console.WriteLine("Failure");
            }
            else if (i[0] < 0 || i[0] > 100)
            {
                Console.WriteLine("Enter a value between 0 and 100");
            }
            else if (i[0] == 999)
            { Console.WriteLine("You enterd 999 to stop ");
            }
            Console.Writeline("You're result is:" + i[0]);
       Console.ReadKey();
        }
