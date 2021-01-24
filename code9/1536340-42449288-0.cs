    Dictionary<char, int> freq = new Dictionary<char, int>();
    
    using (StreamReader sr = new StreamReader(@"yourBigFile")) {
        string line;
        while ((line = sr.ReadLine()) != null) {
            foreach (char c in line) {
                if (!freq.ContainsKey(c)) {
                    freq[c] = 0;
                }
                freq[c]++;
            }
        }
    }
    
    var result = freq.Where(c => char.IsLetterOrDigit(c.Key)).OrderByDescending(x => x.Value).Take(10);
    Console.WriteLine(string.Join(Environment.NewLine, result));
