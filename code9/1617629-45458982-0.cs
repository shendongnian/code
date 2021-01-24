    void Main()
    {
    	string txt = @"[Global]
    asd
    dsa
    akl
    ASd
    
    [Test2]
    bnmnb
    hkhjk
    tzutzi
    Tzutzi
    Tzitzi
    
    [Test3]
    5675
    46546
    464
    564
    56456
    45645654
    4565464
    
    [other]
    sdfsd
    dsf
    sdf
    dsfs";
    
    	string[] split = txt.Split('[');
    	foreach(var s in split)
    	{
    		var subsplits = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    		Console.WriteLine(subsplits[0]);
    		foreach(var ss in subsplits)
    		{
    			if(!ss.Contains("]"))
    				Console.WriteLine(ss);
    		}
    	}
    }
