    public string GetNewString(string input)
    {
        // Skip empty strings, may not be needed if you know there's always a length > 0
        if (string.IsNullOrWhiteSpace(input))
		    return input;
        // Decides whether we convert to uppercase
	    bool convert = false;
	    
        // Will build the new string
	    StringBuilder sb = new StringBuilder();
        // Process each character individually
	    foreach (char c in input)
	    {
            // If character is an underscore skip it and get ready to uppercase the next letter
		    if (c == '_')
		    {
			    convert = true;
			    continue;
		    }
		
            // If we need to convert then uppercase the character and add it to the new string
		    if (convert)
		    {
                // Only uppercase if possible
			    if (Char.IsLetter(c))
			    {
				    sb.Append(Char.ToUpper(c));
			    }
			    else
			    {
                    // Must be a number or symbol or whatever
				    sb.Append(c);
			    }
			
		   convert = false;
		   }
		   else
		    {
                // No need to convert, add it as is
			    sb.Append(c);
		    }
	    }
	
        // Return the new string
	    return sb.ToString();
    }
