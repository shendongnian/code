	void Main()
	{
		DirectoryInfo startDirectory = new DirectoryInfo(@"C:\Users\Angelo\Desktop\ExerciseTest");
	
		StringBuilder sb = new StringBuilder();
	
		DirectoryInfo[] subDirectoryes = startDirectory.GetDirectories("*", SearchOption.AllDirectories);
	
		for (int i = 0; i < subDirectoryes.Length; i++)
		{
			var level = subDirectoryes[i].FullName.Split('\\').Count();
			sb.AppendLine($"{new string('\t', level)}{subDirectoryes[i].Name}");
		}
	
		Console.WriteLine(sb.ToString());
	
		Console.ReadLine();
	}
