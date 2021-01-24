	using(var en = text.GetEnumerator())
	{
		while (en.MoveNext())
		{
			char c = en.Current;
	        if (c == ' ' && tempText == "")
	        {
	            //nothing has to be done
	        }
	        else if (c != '\t')
	        {
	            tempText += c;
	        }
	    }
	}
