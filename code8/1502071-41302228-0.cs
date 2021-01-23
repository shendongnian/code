        public IEnumerable<string> GetProxyList(string FileName)
        {
            string[] allLines = File.ReadAllLines(FileName);
            var result = new List<string>(allLines.Length);
            foreach (string line in allLines)
            {
                var splittedLine = line.Split(':');
                result.Add($"[{splittedLine[0]}][{splittedLine[1]}]");
            }
            return result;
        }
