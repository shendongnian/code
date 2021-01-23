    var str = "SERVERERROR             = Error!Please Contact admin."+
					"ERRORSTACKTRACE         = Stack Trace";
		
		var output = new Dictionary<string,string>();
		
		foreach(var item in str.Split('.').ToList()){
			var kv = item.Split('=');
			output.Add(kv[0].Trim(),kv[1].Trim());
		}
		
		Console.WriteLine(output["SERVERERROR"]);
		Console.WriteLine(output["ERRORSTACKTRACE"]);
