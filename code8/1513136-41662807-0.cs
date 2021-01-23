	public static string GetShortcutTargetFile(string shortcutFilename)
	{
		if (File.Exists(shortcutFilename))
		{
			var shell = new WshShell();
			var link = (IWshShortcut)shell.CreateShortcut(shortcutFilename);
			return link.TargetPath;
		}
		return string.Empty;
	}
	public static Dictionary<string, string> CreateDictionary(string path)
	{
		var dictionary = new Dictionary<string, string>();
		foreach (var filePath in Directory.EnumerateFiles(path, "*.lnk", SearchOption.AllDirectories))
		{
			var lnkPath = GetShortcutTargetFile(filePath);
			if (lnkPath.Length > 0 && !dictionary.ContainsKey(lnkPath))
			{
				dictionary.Add(lnkPath, Path.GetFileNameWithoutExtension(filePath));
			}
		}
		
		return dictionary;
	}
	
	static void Main()
	{
		var startMenuLocation = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
		var dictionary = CreateDictionary(startMenuLocation);
		foreach (var p in Process.GetProcesses())
		{
			try
			{
				if (!string.IsNullOrEmpty(p.MainWindowTitle))
				{
					var pair = dictionary.FirstOrDefault(entry => entry.Key.Contains(p.ProcessName));
					var prettyName = pair.Value;
					Console.WriteLine(string.Format("Process Name: " + prettyName));
				}
			}
			catch
			{
			}
		}
	}
