	void Main()
	{
        var path = @"C:\Users\Angelo\Desktop\ExerciseTest";
        var initialDepth = path.Split('\\').Count();
		DirectoryInfo startDirectory = new DirectoryInfo(path);
	
		StringBuilder sb = new StringBuilder();
	
		DirectoryInfo[] subDirectoryes = startDirectory.GetDirectories("*", SearchOption.AllDirectories);
	
		for (int i = 0; i < subDirectoryes.Length; i++)
		{
			var level = subDirectoryes[i].FullName.Split('\\').Count() - initialDepth;
			sb.AppendLine($"{new string('\t', level)}{subDirectoryes[i].Name}");
		}
	
		Console.WriteLine(sb.ToString());
	
		Console.ReadLine();
	}
