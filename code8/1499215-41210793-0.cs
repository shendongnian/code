    if (File.Exists("textpath.txt"))
            {
                string text = File.ReadAllText("textpath.txt");
                if (text.Length < 5)
                {
                    Console.WriteLine("File does not contains 5 characters");
                }
                else
                {
                    File.WriteAllText("newFilePath.txt", text.Substring(5).ToString());
                    Console.WriteLine("Complete");
                }
            }
            else
            {
                Console.WriteLine("File not exist");
            }
