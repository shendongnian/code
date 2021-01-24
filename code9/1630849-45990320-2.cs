            // Method 1 Linq
            string output = string.Concat(("tung2003".ToCharArray()
                .Select(s=> char.IsDigit(s) ? s.ToString() : ((int)s).ToString())));
            // Method 2
            string input = "tung2003";
            string output = string.Empty;
            foreach (char c in input)
            {
                if (Char.IsDigit(c)) output += c.ToString();
                else output += ((int)c).ToString();
            }
