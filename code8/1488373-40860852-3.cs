        string Format(string str, string separator)
        {
            var delimiter = char.Parse(separator);
            var replaced = false;
            var cArray = str.Select(c =>
            {                
                if (!char.IsLetterOrDigit(c) & !replaced)
                {
                    replaced = true;
                    return delimiter;
                }
                else if (char.IsLetterOrDigit(c))
                {
                    replaced = false;                    
                }
                else
                {
                    return ' ';
                }
                return c;
                
            }).ToArray();
            return new string(cArray).Replace(" ","");
        }
