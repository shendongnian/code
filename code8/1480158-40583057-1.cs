	//From wherever you are reading it.
	string jsonstr = "Your Json String";
	//I Removed all the / and \ from the string
	jsonstr = jsonstr.Replace("/", "");
	jsonstr = jsonstr.Replace("\\", "");
	//at last of the string you have something like this 
    //;\n        .menuTypes = [\"DEFAULT\",\"FOOD\",\"BAR\",\"DELIVERY\",\"SPECIAL\",\"TAKEAWAY\",\"INTERNAL\"];\n
	//which is not the part of the JSON string. So I removed that part as well to make it a valid JSON
	jsonstr = jsonstr.Remove(jsonstr.IndexOf(";n"));
	//Console.WriteLine(jsonstr); //You can uncomment it to see how JSON looks after cleaning.
	//Just Deserialize the JSON
	List<YourData> yd = JsonConvert.DeserializeObject<List<YourData>>(jsonstr);
	//Loop to get all the filenames or any other fields you want 
	foreach(YourData ydd in yd)
	{
		Console.WriteLine(ydd.filename);
	}
