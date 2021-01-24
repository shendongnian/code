	Regex linkRegex = new RegEx(@"((~\/link\.aspx\?_id=([A-Z0-9]{32})[^""]+))", RegexOptions.Compiled);
    StringBuilder result = new StringBuilder();
	Match match = linkRegex.Match(bodyText); // Reset
	int lastEnd = 0;
	if (match.Success)
	{
		do
		{
			string value = match.Groups[3].Value;
			string replacement = string.Format("/{0}/mylink.aspx", value);
			result.Append(bodyText.Substring(lastEnd, match.Index - lastEnd)); // Remove the match
			result.Append(replacement); // Append replacement 
			lastEnd = match.Index + match.Length;
		} while ((match = match.NextMatch()).Success);
	}
	result.Append(bodyText.Substring(lastEnd)); // Append tail
    bodyText = result.ToString();
