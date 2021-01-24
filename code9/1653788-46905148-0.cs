    var s = "#Abc=\"\"";
	var result = Regex.Replace(s, "#[A-Za-z0-9]+(=\"\")", m=> 
	    string.Format("{0}{1}{2}", 
	       m.Value.Substring(0, m.Groups[1].Index), // Get the substring up to Group 1 value
	       new string('?', m.Groups[1].Length), // Build the string of Group 1 length ?s
	       m.Value.Substring(m.Groups[1].Index+m.Groups[1].Length,  m.Value.Length-m.Groups[1].Index-m.Groups[1].Length))); // Append the rest of the match
	Console.WriteLine(result);
