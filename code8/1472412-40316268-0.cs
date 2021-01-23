    static void Main(string[] args)
            {
                bool Exist = false;
                StringBuilder sb = new StringBuilder();
                Console.WriteLine("enter your string");
                String Hello = Console.ReadLine();
                string pathToFile = "Path";
                foreach (var line in File.ReadAllLines(pathToFile))
                {
                    sb.Append(line);
                    if (line.Contains(Hello))
                        Exist = true;
                    sb.Append("\n");
                }
                if (Exist)
                {
                    StringBuilder newSb = new StringBuilder();
                    newSb.Append("-------------------\n");
                    newSb.Append(Hello + "\n");
                    newSb.Append("-------------------\n");
                    StringBuilder text = newSb.Append(sb);
                    File.WriteAllText(pathToFile, text.ToString());
                    Console.WriteLine("done");
                }
                else
                {
                    Console.WriteLine("word not found!");
                   
                }
                Console.ReadLine();
            }
