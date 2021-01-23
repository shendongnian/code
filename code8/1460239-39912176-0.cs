      public static void addData()
                {
                    for (int i = 0; i < myArray.Length; i++)
                    {
                        bool success = false;
                        while (!success)
                        {
                            Console.WriteLine("Enter a number you would like to add");
                            string input = Console.ReadLine();
                            double number;
                            if (Double.TryParse(input, out number))
                            {
                                success = true;
                                myArray[i] = number;
                            }
        
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number")
                            }
                        }
                    }
                }
