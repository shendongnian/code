    string[] splitChar = new string[] { "+=", "-=" };
	string content = "5+=2";		
	var stringPresent = splitChar.FirstOrDefault(x=>content.Contains(x));
	if(String.IsNullOrEmpty(stringPresent))
		Console.WriteLine("Not found");
	else
	Console.WriteLine(stringPresent);
