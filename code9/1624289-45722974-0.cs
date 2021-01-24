	public static string GetFileName(string path, string name)
	{
		var fileName = $@"{path}\{name}.xlsx";
		int i = 0;
		while (System.IO.File.Exists(fileName))
		{
			i++;
			fileName = $@"{path}\{name}({i}).xlsx";
		}
		return fileName;
	}
	public void saveloop()
	{
		var fileName = GetFileName(path, name);
		// use fileName from this point on
	}	
