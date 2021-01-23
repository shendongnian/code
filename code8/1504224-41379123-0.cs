    void Main()
    {
        var code = File.ReadAllText(@"d:\temp\test.c");
        code.Dump("input");
    
        bool inString = false;
        bool inSingleLineComment = false;
        bool inMultiLineComment = false;
    
        var output = new StringBuilder();
        int index = 0;
    
        while (index < code.Length)
        {
            // First deal with single line comments: // xyz
            if (inSingleLineComment)
            {
                if (code[index] == '\n' || code[index] == '\r')
                {
                    inSingleLineComment = false;
                    output.Append(code[index]);
                    index++;
                }
                else
                    index++;
    
                continue;
            }
    
            // Then multi-line comments: /* ... */
            if (inMultiLineComment)
            {
                if (code[index] == '*' && index + 1 < code.Length && code[index + 1] == '/')
                {
                    inMultiLineComment = false;
                    index += 2;
                }
                else
                    index++;
                continue;
            }
    
            // Then deal with strings
            if (inString)
            {
                output.Append(code[index]);
                if (code[index] == '"')
                    inString = false;
                index++;
                continue;
            }
    
            // If we get here we're not in a string or in a comment
            if (code[index] == '"')
            {
                // We found the start of a string
                output.Append(code[index]);
                inString = true;
                index++;
            }
            else if (code[index] == '/' && index + 1 < code.Length && code[index + 1] == '/')
            {
                // We found the start of a single line comment
                inSingleLineComment = true;
                index++;
            }
            else if (code[index] == '/' && index + 1 < code.Length && code[index + 1] == '*')
            {
                // We found the start of a multi line comment
                inMultiLineComment = true;
                index++;
            }
            else
            {
                // Just another character
                output.Append(code[index]);
                index++;
            }
        }
    
        output.ToString().Dump("output");
    }
