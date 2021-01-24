    string samplevalue = "1. e40 e51 2. f31 f56 (f16) 3. j40 h51 4. k31 (c18) k56 ", newstring = string.Empty;
                bool isstart = false;
                foreach (char c in samplevalue)
                {
                    if (c == '(')
                    {
                        isstart = true;
    
                    }
    
                    if (isstart)
                    {
                        if (c == ')')
                        { isstart = false; }
    
                    }
                    else { newstring += c.ToString(); }
    
                }
