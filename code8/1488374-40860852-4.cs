        string Format(string str, string separator)
        {
            var delimiter = char.Parse(separator);            
            var cArray = str.Select(c => !char.IsLetterOrDigit(c) ? delimiter : c).ToArray();
            var wlist = new string(cArray).Split(delimiter).Where(a => a.Count() > 0).ToList();
            return string.Join(separator, wlist);
        }
