    foreach (string file in Directory.EnumerateFiles(args[0].Replace("\"",""), "*.*"))
                {
                    string contents = File.ReadAllText(file);
                    Console.WriteLine(contents);
                }
