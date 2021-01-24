	/// <summary>
	/// How many characters should get read at once max.
	/// </summary>
	private static readonly int BUFFER_SIZE = 4096;
	private StreamSocket socket;
	private StreamWriter writer;
	private StreamReader reader;
	protected async Task<string> readNextStringAsync()
	{
		string result = "";
		while (true)
		{
			char[] buffer = new char[BUFFER_SIZE + 1];
			// Read next BUFFER_SIZE chars:
			reader.ReadAsync(buffer, 0, BUFFER_SIZE);
			// Cut the read string and remove everything starting from the first "\0":
			string data = new string(buffer).Substring(0, buffer.Length - 1);
			int index = data.IndexOf("\0");
			if (index < 0)
			{
				index = data.Length;
			}
			data = data.Substring(0, index);
			// Is data left to read?
			if (reader.Peek() < 0)
			{
				// No? then break:
				result += data;
				break;
			}
			result += data;
		}
		return result;
	}
