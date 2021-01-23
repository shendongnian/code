            public string Transform(string input)
            {
                var stringBuilder = new StringBuilder();
                string separator = null;
    
                foreach (var word in input.Split('_').Where(w => w.Length > 0))
                {
                    if (separator == null)
                        separator = " ";
                    else
                        stringBuilder.Append(separator);
    
                    var firstLetter = word.Substring(0, 1);
                    stringBuilder.Append(firstLetter.ToUpper());
                    stringBuilder.Append(word.Substring(1));
                }
                return stringBuilder.ToString();
            }
