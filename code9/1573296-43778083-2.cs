            using (StreamReader inputStream = new StreamReader(filepath, System.Text.Encoding.UTF8))
            {
                while ((line = inputStream.ReadLine()) != null)
                {
                    Console.WriteLine(line);                  
                }
            }
