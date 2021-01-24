    string GetNetworkPath(string path)
    {
    	string root = Path.GetPathRoot(path);
    	
    	// validate input, in your case you are expecting a path starting with a root of type "E:\"
        // see Path.GetPathRoot on MSDN for returned values
    	if (string.IsNullOrWhiteSpace(root) || !root.Contains(":"))
    	{
    		// handle invalid input the way you prefer
    		// I would throw!
    		throw new ApplicationException("be gentle, pass to this function the expected kind of path!");
    	}
    	path = path.Remove(0, root.Length);
    	return Path.Combine(@"\\myPc", path);
    }
 
 
