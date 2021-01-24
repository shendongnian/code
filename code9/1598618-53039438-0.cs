    protected string hasSpecialChar(string input)
            {
                string[] replaceables = new[] { @"\", "|", "!", "#", "$", "%", "&", "/", "=", "?", "»", "«", "@", "£", "§", "€", "{", "}", "^", ";", "'", "<", ">", ",", "`" };
                string rxString = string.Join("|", replaceables.Select(s => Regex.Escape(s)));
                return Regex.Replace(input, rxString, string.Empty);
            }
