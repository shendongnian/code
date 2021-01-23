	string data = "#FirstName=Arvind #LastName= Chaudhary_009";
	data = data.Replace("_", "");
	string[] dt = data.Split(new char[] {'#'}, StringSplitOptions.RemoveEmptyEntries);
	Regex regex = new Regex(@"#");
	string[] dt1 = regex.Split(data).Where(s => s != String.Empty).ToArray();
	foreach(string d in dt)
	{
		//this will print both the line
		Console.WriteLine(d);
	}
	foreach(string d in dt1)
	{
		//this will print both the line
		Console.WriteLine(d);
	}
