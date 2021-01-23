     private static void note()
        {
            int[] i = new int[1];
            // Make sure this is an infinite loop
            do
            {
                Console.WriteLine("Please enter test result");
                bool result = int.TryParse(Console.ReadLine(), out i[0]);
                if (!result)
                {
                    Console.WriteLine("Please enter a number");
                    continue;
                }
                // Test for this and the next conditions first - this'll allow us to shorten the other "if" statements
                if (i[0] == 999)
                {
                    Console.WriteLine("You entered 999 to stop");
                    // End the loop
                    break;
                }
                // The only valid answer that's > 100 is 999
                else if (i[0] < 0 || i[0] > 100)
                {
                    Console.WriteLine("Enter a value between 0 and 100");
                }
                // We can't run this condition first because if we did "5000" would "count" as an A (rather than an invalid condition)
                else if (i[0] >= 90)
                {
                    Console.WriteLine("note is A");
                }
                // No need to explicitly check to see if this is < 90, we know it must be
                // by virtue of the fact that the previous condition is false
                else if (i[0] >= 80)
                {
                    Console.WriteLine("note is B");
                }
                else if (i[0] >= 70)
                {
                    Console.WriteLine("note is C");
                }
                else if (i[0] >= 60)
                {
                    Console.WriteLine("note is D");
                }
                else if (i[0] < 60)
                {
                    Console.WriteLine("Failure");
                }
                 Console.WriteLine("Your result is:" + i[0]);
            } while (true);
        }
