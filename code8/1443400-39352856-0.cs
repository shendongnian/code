            string a = "HELLO";
            string b = "GOODBYE";
            foreach (char c in a.ToCharArray())
            {
                if (b.Contains(c)) { b = b.Replace(c.ToString(), string.Empty); }
            }
