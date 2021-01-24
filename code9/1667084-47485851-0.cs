            int age;
            string ageStr = Console.ReadLine();
            if (!int.TryParse(ageStr, out age))
            {
                Console.WriteLine("Please enter valid input for age ! ");
                return;
            }
