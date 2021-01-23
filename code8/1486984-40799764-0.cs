    public static void WriteMessage(string message)
        {
            string path = @"log.txt"; //File path
            FileStream stream;
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite); //This section used to read and write operations
                using (StreamWriter writer = new StreamWriter(stream)) //Writing words to the text file
                {
                     //Here is the exception - It's being used by another process
                    if (lines.Length > 0)
                    {
                        writer.WriteLine("\n" + "Another Line Added - " + message);
                        writer.Flush();
                    }
                }
            }
            else
            {
                /**If text file is created for the first time - Starts**/
                stream = new FileStream(path, FileMode.Create); //This section used to read and write operations
                using (StreamWriter writer = new StreamWriter(stream)) //Writing words to the text file
                {
                    writer.WriteLine(message);
                    writer.Flush();
                }
                /**If text file is created for the first time - Ends**/
            }
        }
