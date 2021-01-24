            string date = DateTime.Now.ToString();
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\folder\\test.txt");
            file.WriteLine(date);
            file.Close();
            // Read file
            DateTime dateTime;
            string firstRowFromFile = File.ReadLines("c:\\folder\\test.txt").First();
            if (DateTime.TryParse(firstRowFromFile, out dateTime))
            {
                // right datetime format
            }
            else
            {
                // wrong datetime format
            }
