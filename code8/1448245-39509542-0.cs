    var di = new DirectoryInfo("c:\\temp");
	var listOfFileExtention = new List<string>();
	foreach (var f in di.GetFiles("*.*", SearchOption.AllDirectories))
	{
		
        if (listOfFileExtention.Any(x => x == f.Extension))
		{
			// your code here
		}
	}
