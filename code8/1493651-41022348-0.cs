	using System.Net;
	using System.Text.RegularExpressions;
	public string GetLabelValue(string url)
	{            
		// download your web page content
		WebClient client = new WebClient();
		string downloadString = client.DownloadString(url);
		// regular expression
		var pattern = @"<label.+id=""lblTest"".{0,}>(.+)</label>";
		var match = Regex.Match(downloadString, pattern, RegexOptions.IgnoreCase);
		// getting the label value
		var labelValue = match.Groups[1].Value;
		return labelValue;
	}
