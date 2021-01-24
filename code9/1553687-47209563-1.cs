	/// <summary>
	/// A function to make the Base64 decoding a little less
	/// verbose below:
	/// </summary>
	string Base64Decode(string value)
	{
		return Encoding.Default.GetString(Convert.FromBase64String(value)); 
	}
	
	// Get the first two segments into an enumerable:
    var pieces = jwt.Split('.').Take(2);
	// Pad them with equals signs to a length that is a multiple of four:
	var paddedPieces = pieces.Select(x => x.PadRight(x.Length + (x.Length % 4), '='));
	// Base64 decode the pieces:
	var decodedPieces = paddedPieces.Select(x => Base64Decode(x));
	// Join it all back into one string with .Aggregate:
	Console.WriteLine(decodedPieces.Aggregate((s1, s2) => s1 + Environment.NewLine + s2));
