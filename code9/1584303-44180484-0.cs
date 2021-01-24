      string[] lines = File.ReadAllLines(@"......");
            for (int i=0;i<lines.Length;i++)
            {
                string line = lines[i];
                foreach (byte b in Encoding.UTF8.GetBytes(line.ToCharArray()))
                {
                   //ASCII code of Quotes is 34 
                    if (b.ToString() == "34")
                        Console.WriteLine("\"" + "at line " + (i+1));
                }
                
            }
