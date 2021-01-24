        for (int i = 0; i < 99; i++)
        {
            string userValue = Console.ReadLine();
            if (userValue.Contains("End"))
                {
                    break;
                }
            int userInt;
            if (int.TryParse(userValue, out userInt))
            {
                userInts.Add(userInt);
            }
        }
