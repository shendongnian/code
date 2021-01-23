    string FormatCode(string input)
    {
        int indexSpace = input.IndexOf(' ');
        
        if (indexSpace == -1)
        {
            // If the string does not contains any space, return it as it.
            return input;
        }
        
        // The index from where we want to append data...
        int index = 0;
        // Preallocate memory using old size as the starting point...
        var builder = new StringBuilder(input.Length);
        
        while(true)
        {
            // Append everything before the current space...
            builder.Append(input.Substring(index, indexSpace - index));
            
            // Decide if we want to keep that space...
            
            // Do not keep initial spaces...
            bool needSpace = indexSpace > 0;
            
            if (needSpace)
            {
                // Do not keep space after selected symbols...
                switch (input[indexSpace - 1])
                {
                    case ',':
                    case ')':
                        needSpace = false;
                        break;
                }
            }
		
            // Find the next character that is not a space as we always want
            // to merge consecutives spaces and detecting them help handle 
            // edge cases.
            int indexNotSpace = indexSpace;
            while (++indexNotSpace < input.Length && input[indexNotSpace] == ' ')
            {
            }
            
            if (indexNotSpace == input.Length)
            {
                // The remaining of the string consist only of spaces...
                break;
            }
		
            if (needSpace)
            {
                // Do not keep spaces before selected symbols...
                switch (input[indexSpace + 1])
                {
                    case ',':
                    case '(':
                        needSpace = false;
                        break;
                }
            }
		
            if (needSpace)
            {
                builder.Append(' ');
            }
	    	
            // Find next space not already processed...
            index = indexNotSpace;
            indexSpace = input.IndexOf(' ', index);
            
            if (indexSpace == -1)
            {
                // There are not remaining space so append remaining text 
                // and exit loop.
                builder.Append(input.Substring(index));
                break;
            }
        }
    
        return builder.ToString();
    }
