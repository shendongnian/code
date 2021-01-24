            string input = @"Folder/UnderFolder/Cat/Pics";
            string[] values = input.Split('/');
            int numOfSlashes = values.Length - 1;
            Console.WriteLine("Number of Slashes = " + numOfSlashes);
            foreach (string val in values)
            {
                Console.WriteLine(val);
            }
