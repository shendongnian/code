    string myString = "12-15-18-20-25-60";
            string[] splittedStrings = myString.Split('-');
            foreach (var splittedString in splittedStrings)
            {
                Console.WriteLine(splittedString + "\n");
            }
            Console.ReadLine();
