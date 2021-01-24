	void SearchAndPopulate(string path, string searchText)
	{
		DirectoryInfo di = new DirectoryInfo(path);
		FileInfo[] files = di.GetFiles("*.txt");
		foreach (FileInfo file in files)
		{
			string content = File.ReadAllLines(file.FullName);
			if (content.Any(line => line.ToLower().Contains(searchText.ToLower())))
			{
				var numClient = content.Select(y => y.Split('='))
					.Where(y => y.Length > 1 && y[0].Trim() == "NUM_CLIENT")
                    .Select(y => y[1])
					.FirstOrDefault();
				if(numClient != null)
					listBox1.Text = numClient;
				else
					// Do something here if "NUM_CLIENT" wasn't in the file.
			}
		}
	}
