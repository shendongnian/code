	using(var en = text.GetEnumerator())
	{
		while (en.MoveNext())
		{
			char c = en.Current;
			if (c != ' ')
			{
				do
				{
					if (c != '\t')
	        		{
	            		tempText += c;
	        		}
				} while (en.MoveNext());
                return tempText;
			}
	    }
        return ""; // only hit if text was all-spaces
	}
