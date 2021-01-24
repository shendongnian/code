    string[] splitChar = new string[] { "+=", "-=" };
	string content = "5+=2";		
	var isPresent = splitChar.FirstOrDefault(x=>content.Contains(x));
	if(String.IsNullOrEmpty(isPresent))
		Console.WriteLine("Not found");
	else
	Console.WriteLine(isPresent);
