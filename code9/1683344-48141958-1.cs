            var lines = File.ReadAllLines(@"C:\filename.txt");
            var newLines = new List<string>();
            foreach (var line in lines)
            {
                var newline = $"('{line}'),";
                newLines.Add(newline);
            }
