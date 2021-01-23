    const string test =
    "this is a test text consisting of various words where some consist of unique characters only while others have duplicates in them.";
    
    var words = test.Split(' ');
    var output=new List<string>();
    foreach (var word in words)
    {
    	var wdArr = word.ToCharArray();
    	if (wdArr.Distinct().Count() == wdArr.Length) // word contains distinct characters only
    	{
    		output.Add(word);
    	}
    }
    Debug.Print(string.Join(" ",output));
