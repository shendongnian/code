            lbl:
            Console.WriteLine("Enter the number of years:");
            string numberOfYearsInput = Console.ReadLine();
            if (Convert.ToInt32(numberOfYearsInput) < 1 || Convert.ToInt32(numberOfYearsInput) > 10)
            {
                Console.WriteLine("Not a valid ammount, try again.");
                goto lbl;
            }
            else
            {
                //Do your code here
            }
