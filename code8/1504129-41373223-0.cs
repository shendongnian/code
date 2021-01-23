    foreach (string a in cprglines)
            {
               foreach (char c in a)
                {
                    if (Char.IsLetter(c))
                    {
                        letters += c;
                    }
                }
    
                list.Add(letters);
            }
