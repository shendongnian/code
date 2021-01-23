            Console.Clear();
            List<int> myCars = new List<int>();
            Console.WriteLine("Enter the car into the lot");
            string input = Console.ReadLine();
            int IntValue;
            if (int.TryParse(input, out IntValue))
            {
                myCars.Add(IntValue);
            }
            while (input != "Done") //The != is not equal to 
            {
                Console.WriteLine("Please enter another integer: ");
                input = Console.ReadLine();
               
                if (int.TryParse(input, out IntValue))
                {
                    myCars.Add(IntValue);
                }
            }
            int sum = 0;
            foreach (int value in myCars)
            {
                sum += value;
            }
            Console.WriteLine("The total of all the cars on the lot are : " + " " + sum.ToString());
            Console.ReadLine();
