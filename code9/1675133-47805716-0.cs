	public static IEnumerable<string> ReadDelimitedRows(StreamReader reader, string delimiter)
	{
		char[] delimChars = delimiter.ToArray();
		int matchCount = 0;
		char[] buffer = new char[512];
		int rc = 0;
		StringBuilder sb = new StringBuilder();
		
		while ((rc = reader.Read(buffer, 0, buffer.Length)) > 0)
		{
			foreach (char c in buffer)
			{
				if (c == delimChars[matchCount])
				{
					if (++matchCount >= delimChars.Length)
					{
						// found full row delimiter
						yield return sb.ToString();
						sb.Clear();
						matchCount = 0;
					}
				}
				else
				{
					if (matchCount > 0)
					{
						// append previously matched portion of the delimiter
						sb.Append(delimChars.Take(matchCount));
						matchCount = 0;
					}
					sb.Append(c);
				}
			}
		}
		// return the last row if found
		if (sb.Length > 0)
			yield return sb.ToString();
	}
