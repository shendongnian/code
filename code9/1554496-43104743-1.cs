    using (var client = new System.Net.Http.HttpClient())
    using (var stream = client.GetStreamAsync("https://github.com/frictionlessdata/specs/archive/master.zip").Result)
    {
    	var basepath = Path.Combine(Path.GetTempPath() + "myzip");
    	System.IO.Directory.CreateDirectory(basepath);
    	
    	var ar = new System.IO.Compression.ZipArchive(stream, System.IO.Compression.ZipArchiveMode.Read);
    	foreach (var entry in ar.Entries)
    	{
    		var path = Path.Combine(basepath, entry.FullName);
    		
    		if (string.IsNullOrEmpty(entry.Name))
    		{
    			System.IO.Directory.CreateDirectory(Path.GetDirectoryName(path));
    			continue;
    		}
    			
    		using (var entryStream = entry.Open())
    		{
    			System.IO.Directory.CreateDirectory(Path.GetDirectoryName(path));
    			using (var file = File.Create(path))
    			{
    				entryStream.CopyTo(file);
    			}
    		}
    	}
    }
