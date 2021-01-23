	string Format(string str, char separator)
	{
		var builder = new StringBuilder (str.Length);
		using (var e = str.GetEnumerator ())
		{
			while (e.MoveNext ())
			{
				if (char.IsLetterOrDigit (e.Current))
					builder.Append (e.Current);
				else
				{
					while (e.MoveNext () && !char.IsLetterOrDigit (e.Current))
                        ;
					builder.Append (separator);
				}
			}
		}
		
		return builder.ToString ();
	}
