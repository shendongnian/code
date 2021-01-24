    string input = "!LOGIN?<USERNAME='user'><PASSWORD='password'>";
    string command = input.Substring(1, input.IndexOf('?') - 1);
    Console.WriteLine($"command: {command}");
    var parameters = input
    					.Replace($"!{command}?", string.Empty)
    					.Replace("<", "")
    					.Split(">".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    
    string[] kvpair;
    foreach(var kv in parameters) {
    	kvpair = kv.Split('=');
    	Console.WriteLine($"pname: {kvpair[0]}, pvalue: {kvpair[1]}");
    }
