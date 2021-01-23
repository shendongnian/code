        public static void WriteMessage(string message)
        {
            var path = @"../../sth.txt"; //File path
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);//This section used to read and write operations
                using (var writer = new StreamWriter(path, true)) //Writing words to the text file
                {
                    if (lines.Length > 0)
                    {
                        writer.WriteLine("Another Line Added - " + message);
                    }
                    else
                    {
                        writer.WriteLine(message);
                    }
                    writer.Flush();
                }
            }
            else
            {
                /**If text file is created for the first time - Starts**/
                using (StreamWriter writer = new StreamWriter(path)) //Writing words to the text file
                {
                    writer.WriteLine(message);
                    writer.Flush();
                }
                /**If text file is created for the first time - Ends**/
            }
        }
