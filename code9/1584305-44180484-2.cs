      string[] lines = File.ReadAllLines(@"txt/txttst");
            for (int i=0;i<lines.Length;i++)
            {
                string line = lines[i];
                // ASCII Code of Quotes is 34
               var bytes = Encoding.UTF8.GetBytes(line.ToCharArray()).ToList();
                if(bytes.Count(b=> b.ToString()=="34")>0)
                    Console.WriteLine("\"" + "at line " + (i + 1));
            }
