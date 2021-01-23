    string input;
            int num, i, x = 0, sum = 0;
            while (true)
            {
                Console.Write("Enter a number: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out num))
                {
                    Console.Write("\nThe factors are: ");
                    for (i = 1; i <= num; i++)
                    {
                        if (num % i == 0)
                        {
                            Console.Write("{0} ", i);
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("\nThat was not a valid number!\n");
                }
            }
            /*for (i = 1; i < num; i++)
            {*/
                if (num % i == 0)
                {
                    sum = sum + i;
                }
                if (sum == num)
                {
                    Console.Write("\n\n{0} is a perfect number.\n", num);
                }
                else
                {
                    Console.Write("\n\n{0} is not a perfect number.\n", num);
                }
                for (i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        x++;
                        break;
                    }
                }
                if (x == 0 && num != 1)
                {
                    Console.Write("\n{0} is a prime number.", num);
                }
                else
                {
                    Console.Write("\n{0} is not a prime number.", num);
                }
                Console.ReadLine(); //this isn't closing the program!
            //}
