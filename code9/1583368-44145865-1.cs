    var pattern = "(\"message\":\\s+\")(?<messageContent>(.*))(\"})";
	var regex = Regex.Match(data, pattern);
	var message = regex.Groups["messageContent"].Value;
	if (!string.IsNullOrEmpty(message))
	{
		message = message.Replace("\"", "\\\"");
		var newData = Regex.Replace(data, pattern, "$1" + message + "$3");
		var jObject = JObject.Parse(newData);
	}
