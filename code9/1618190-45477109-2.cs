    DirectoryInfo di = new DirectoryInfo(scriptLocation);
    FileInfo[] rgFiles = di.GetFiles("*.txt");
    foreach (FileInfo fi in rgFiles)
    {
        string [] alllines = System.IO.File.ReadAllLines(fi.FullName);
		for (int i = 0; i < alllines.Length; i++)
		{
			if(alllines[i].Contains("$")
			{
				// prompt
                int dollarIndex = script.IndexOf("$");
                string nextTenChars = script.Substring(dollarIndex - 17, 17);
                string promptValue = CreateInput.ShowDialog(nextTenChars, "Input");			
			    alllines[i] = alllines[i].Replace("$", promptValue) ;
			}
        }
	}
