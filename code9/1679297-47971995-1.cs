        private async Task WriteToFileAsAsync()
        {
            string file = @"sample.txt";
            using (FileStream stream = new FileStream(file, FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        await streamWriter.WriteLineAsync(i.ToString());
                    }
                }
            }
        }
