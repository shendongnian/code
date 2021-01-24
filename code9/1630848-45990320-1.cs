            string input = "tung2003";
            string output = string.Empty;
            foreach (char c in input)
            {
                if (Char.IsDigit(c)) output += c.ToString();
                else output += ((int)c).ToString();
            }
