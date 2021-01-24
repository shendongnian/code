    public int GetIndexOfDriveLetter(string drive)
    {
    	drive = drive.Replace(":", "").Replace(@"\", "");
    
    	// execute DiskPart programatically
    	Process process = new Process();
    	process.StartInfo.FileName = "diskpart.exe";
    	process.StartInfo.UseShellExecute = false;
    	process.StartInfo.CreateNoWindow = true;
    	process.StartInfo.RedirectStandardInput = true;
    	process.StartInfo.RedirectStandardOutput = true;
    	process.Start();
    	process.StandardInput.WriteLine("list volume");
    	process.StandardInput.WriteLine("exit");
    	string output = process.StandardOutput.ReadToEnd();
    	process.WaitForExit();
    
    	// extract information from output
    	string table = output.Split(new string[] { "DISKPART>" }, StringSplitOptions.None)[1];
    	var rows = table.Split(new string[] { "\n" }, StringSplitOptions.None);
    	for (int i = 3; i < rows.Length; i++)
    	{
    		if (rows[i].Contains("Volume"))
    		{
    			int index = Int32.Parse(rows[i].Split(new string[] { " " }, StringSplitOptions.None)[3]);
    			string label = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[8];
    
    			if (label.Equals(drive))
    			{
    				return index;
    			}
    		}
    	}
    
    	return -1;
    }
