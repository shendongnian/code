            try
            {
                //the program reads the record and displays it on the screen
                record = reader.ReadLine();
                while (record != null)
                {
                    string[] array = record.Split(new char[] {' ', '\r', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    foreach(string word in array)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
