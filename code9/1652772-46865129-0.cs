        static void Main()
        {
            //int k;
            int min;
            int max;
            int odd = 0;
         
            Console.WriteLine("Enter minimum integer: ");
            min = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter maximum integer: ");
            max = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter your number: ");
            bool userIsTyping = true;
            while (userIsTyping)
            {
                Console.WriteLine("Enter another number: ");            
                int userNumber = int.Parse(Console.ReadLine());
                if (userNumber == 0)
                {
                    userIsTyping = false;
                }
                else if (userNumber > max)
                {
                    Console.WriteLine("The number is out of bounds: greater than max.");
                }
                else if (userNumber < min)
                {
                    Console.WriteLine("The number is out of bounds: less than min.");
                }
                else
                {
                    if (userNumber % 2 != 0)
                    {
                        odd += userNumber;
                        Console.WriteLine("Current Total: " + odd.ToString());
                    }
                    else
                    {
                        Console.WriteLine("That is not an odd number.");
                    }
                }
            }
            Console.WriteLine("The final result is: " + odd.ToString());
            Console.ReadLine();
        }
