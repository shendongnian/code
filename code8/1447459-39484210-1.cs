    using (var fs = new System.IO.FileStream("file.txt", AccessMode.Read)){
    	using (var sr = new System.IO.StreamReader(fs)){
    		//Read file via sr.Read(), sr.ReadLine, ...
    	}
    }//Since StreamReader and FileStream implement IDisposable, they will be freed automatically, so you don't need to call .Close() or .Dispose()
