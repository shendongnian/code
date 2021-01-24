	void Download(string folder, string targetfile, string localPath)
	{
		var dbx = new DropboxClient(Form1.api);
		var response = dbx.Files.Download(folder + "/" + targetfile);
		ulong fileSize = response.Response.Size;
		const int bufferSize = 1024 * 1024;
		var buffer = new byte[bufferSize];
		string folderName = @"C:\dropboxTest\teasdfst.exe";
		using (var stream = response.GetContentAsStream())
		{
			using (var localfile = new FileStream(folderName, FileMode.OpenOrCreate))
			{
				var length = stream.Read(buffer, 0, bufferSize);
				while (length > 0)
				{
					localfile.Write(buffer, 0, length);
				   // Console.WriteLine(localfile.);
					var percentage = 100 * (ulong)localfile.Length / fileSize;
					// Update progress bar with the percentage.
					// progressBar.Value = (int)percentage
					//Console.WriteLine(percentage);
					length = stream.Read(buffer, 0, bufferSize);
				}
			}
		}
	}
