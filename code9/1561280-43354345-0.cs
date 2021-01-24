            string[] lines = File.ReadAllLines(@"C:\YourFile.txt");
            List<string> source = new List<string>();
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                source.Add(lines[new Random().Next(lines.Length)]);
            }
