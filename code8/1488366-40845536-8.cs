	string Format(string str, string separator)
	{
    	var builder = new StringBuilder (str.Length);
    	using (var e = str.GetEnumerator ())
	    {
    	    while (e.MoveNext ())
        	{
				bool hasMoved = true;
				
            	if (!char.IsLetterOrDigit (e.Current))
				{
        	        while ((hasMoved = e.MoveNext ()) && !char.IsLetterOrDigit (e.Current))
            	        ;
                	builder.Append (separator);
	            }
				if (hasMoved)
					builder.Append (e.Current);
    	    }
	    }
	    return builder.ToString ();
	}
