    public class Scripts
    {
        readonly List<Script> scripts;
    
        public Scripts()
        {
            using (var webClient = new WebClient())
            {
                const string url = "ftp://www.unicode.org/Public/UNIDATA/Blocks.txt";
                var blocks = webClient.DownloadString(url);
                var regex = new Regex(@"^(?<from>[0-9A-F]{4})\.\.(?<to>[0-9A-F]{4}); (?<name>.+)$");
                scripts = blocks
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => regex.Match(line))
                    .Where(match => match.Success)
                    .Select(match => new Script(
                        Convert.ToInt32(match.Groups["from"].Value, 16),
                        Convert.ToInt32(match.Groups["to"].Value, 16),
                        NormalizeName(match.Groups["name"].Value)))
                    .ToList();
            }
        }
    
        public string GetScript(char c)
        {
            if (!char.IsLetterOrDigit(c))
                // Use the empty string to signal space and punctuation.
                return string.Empty;
            // Linear search - can be improved by using binary search.
            foreach (var script in scripts)
                if (script.Contains(c))
                    return script.Name;
            return string.Empty;
        }
    
        // Add more special names if required.
        HashSet<string> specialNames = new HashSet<string> { "Latin", "Cyrillic", "Arabic", "CJK" };
    
        string NormalizeName(string name) => specialNames.FirstOrDefault(sn => name.Contains(sn)) ?? name;
    }
