    internal static string ConvertToAscii(string str)
    {
	    var returnStringBuilder = new StringBuilder();
	    foreach (var c in str)
	    {
		    if (char.IsControl(c))
		    {
			    // Control character
			    continue;
		    }
		    if (c < 127)
		    {
			    // ASCII Character
			    returnStringBuilder.Append(c);
		    }
		    else
		    {
			    returnStringBuilder.Append("U+" + ((int) c).ToString("X4"));
		    }
	    }
	    return returnStringBuilder.ToString();
    }
