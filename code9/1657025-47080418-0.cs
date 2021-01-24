	List<string> deletedDirectories = new List<string>();
	
	foreach (DirectoryInfo dir in diArr)
	{
		if (dir.LastWriteTime < DateTime.Parse(daysPast))
		{
			Directory.Delete(dir.FullName, true);
			deletedDirectories.Add(dir.FullName);
		}
	}
		
	using (StreamWriter sw = new StreamWriter(fileName, false))
	{
		sw.WriteLine("File(s) deleted on: " + DateTime.Now);
		sw.WriteLine("============================================");
		sw.WriteLine("");
		
		foreach (string deletedDirectory in deletedDirectories)
		{
			sw.WriteLine(deletedDirectory, false);
		}
		
		sw.WriteLine("");
		sw.WriteLine("End of list");
		sw.WriteLine("");
	}
