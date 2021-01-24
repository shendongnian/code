        private void WriteToFile()
        {
            string file = @"sample.txt";
            using (FileStream stream = new FileStream(file, FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        streamWriter.WriteLine(i.ToString());
                    }
                }
            }
        }
