	using (var client = new WebClient())
	{		
		var content = client.DownloadString("https://vine.co/v/eYgeYlYAOQv");
		
		var postIdMatch = Regex.Match(
            content, 
            @"vine://post/(\d+)[^\d]|""postIdStr"":\s*""(\d+)""");
		
		if (postIdMatch.Success)
			Console.WriteLine(
				postIdMatch.Groups[1].Value != string.Empty 
					? postIdMatch.Groups[1].Value 
					: postIdMatch.Groups[2].Value);
		else
			Console.WriteLine("No post ID found.");
	}
