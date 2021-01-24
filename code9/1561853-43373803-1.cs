    var sentence = "Hello, john!";
	var parts = sentence.Split(' ');
	var reversed = new StringBuilder();
	var charPositions = sentence.Select((c, idx) => new { Char = c, Index = idx })
				                .Where(_ => !char.IsLetterOrDigit(_.Char))
				                .Select(_ => _);
 
	for (int i = 0; i < parts.Length; i++)
	{
		 var chars = parts[i].ToCharArray();
				
		 for (int j = chars.Length - 1; j >= 0; j--)
		 {
			 if (char.IsLetterOrDigit(chars[j]))
			 {
				reversed.Append(chars[j]);
			 }
		 }
	}
	foreach (var ch in charPositions)
	{
		reversed.Insert(ch.Index, ch.Char);
	}
    // olleH, nhoj!
	Console.WriteLine(reversed.ToString());
