	public void CopyAll(DirectoryInfo source, DirectoryInfo target)
	{
		string source4count = source.ToString();
		if (checkSubdirCase == 0)
		{
			allfiles = System.IO.Directory.GetFiles(source4count, "*.*", System.IO.SearchOption.AllDirectories);
			allFilesNum = allfiles.Length;
			progressbarinterval = 0;                    
			progressbarinterval = 100 / allFilesNum;
			Progressbarvalue = 0;
		}
		if (Directory.Exists(target.FullName) == false)
		{
			Directory.CreateDirectory(target.FullName);
		}
		foreach (FileInfo fi in source.GetFiles())
		{
			//HERE IS THE UPDATING OF THE PROGRESSBAR
			fi.CopyTo(System.IO.Path.Combine(target.ToString(), fi.Name), true);
			Progressbarvalue = Progressbarvalue + progressbarinterval;                      
			ProgressBarCopy.Invoke(new MethodInvoker(delegate { ProgressBarCopy.Value = Progressbarvalue; }));
		}
		foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
		{
			DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
			checkSubdirCase = 1;
			CopyAll(diSourceSubDir, nextTargetSubDir);
		}
	}
