           string[] lines = File.ReadAllLines(@filename);
            for (int y = 0; y < lines.Length; y++)
            {
                    Console.WriteLine(lines[y]);
                     string[] columns = lines[y].Split('=');
                    // Columns should have two entries, one for codeX and another one for value. Since you only need the latter, print the second entry in columns 
                    Console.WriteLine(columns[1]);
                    Console.ReadKey();
                }
           }
    }
