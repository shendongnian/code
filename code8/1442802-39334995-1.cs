    string s = "[txtItalic]This is italic[/txtItalic] [txtBold] Bold Text [/txtBold]";
    //creating a list of tags
    List<string> tags = new List<string>();
    tags.Add("txtItalic");
    tags.Add("txtBold");
    //iterating through each of the tags
    foreach (string tag in tags)
    {
    	var startTag = "[" + tag + "]";
    	int startIndex = s.IndexOf(startTag) + startTag.Length;
    	int endIndex = s.IndexOf("[/" + tag + "]", startIndex);
    	string s1 = s.Substring(startIndex, endIndex - startIndex);
    	Console.Write(s1);
    }
