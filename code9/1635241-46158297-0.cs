    Action<string, string> downloadBrowser = null;
    downloadBrowser = new Action<string, string>((tempDir, file) => {
		Console.WriteLine(string.Format("Downloading file '{0}'", file));
		
		const int bufferLength = 1024;
		var megaByteSize = (bufferLength * 500);
		
		var dlRequest = (FtpWebRequest) WebRequest.Create(FTP_SITE + file);
		dlRequest.Method = WebRequestMethods.Ftp.DownloadFile;
		dlRequest.UseBinary = true;
		using (var dlResponse = dlRequest.GetResponse())
		{
			var dlResponseStream = dlResponse.GetResponseStream();
			var fileName = Path.Combine(tempDir, file);
			using (var fs = new FileStream(fileName, FileMode.Create))
			{				
				var buffer = new byte[bufferLength];
				var progressLimit = megaByteSize;
				var bytesRead = 0;
				do {
					bytesRead = dlResponseStream.Read(buffer, 0, bufferLength);
					fs.Write(buffer, 0, bytesRead);
					if (fs.Length > progressLimit) {
						Console.Write("*");
						progressLimit += megaByteSize;
					}
				} while (bytesRead > 0);
			}
		}
		
		Console.WriteLine("\nDownload Complete");
	});
