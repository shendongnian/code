    void Main()
    {
    	string text = "I want to find the number (30)";
    
    	Stopwatch sw = Stopwatch.StartNew();
    
    	for (int i = 0; i < 100000; i++)
    	{
    		TestMethod1();
    	}
    	
    	sw.Elapsed.TotalMilliseconds.Dump("Substring no parameter");	
    	sw = Stopwatch.StartNew();
    
    	for (int i = 0; i < 100000; i++)
    	{
    		TestMethod1(text);
    	}
    
    	sw.Elapsed.TotalMilliseconds.Dump("Substring parameter");
    	sw = Stopwatch.StartNew();
    
    	for (int i = 0; i < 100000; i++)
    	{
    		TestMethod2();
    	}
    
    	sw.Elapsed.TotalMilliseconds.Dump("LINQ no parameter");
    	sw = Stopwatch.StartNew();
    
    	for (int i = 0; i < 100000; i++)
    	{
    		TestMethod2(text);
    	}
    
    	sw.Elapsed.TotalMilliseconds.Dump("LINQ parameter");
    	sw = Stopwatch.StartNew();
    
    	for (int i = 0; i < 100000; i++)
    	{
    		TestMethod3(text);
    	}
    
    	sw.Elapsed.TotalMilliseconds.Dump("Regex In");
    	sw = Stopwatch.StartNew();
    
    	for (int i = 0; i < 100000; i++)
    	{
    		TestMethod4(text);
    	}
    
    	sw.Elapsed.TotalMilliseconds.Dump("Regex Out");
    	sw = Stopwatch.StartNew();
    	sw.Stop();
    }
    
    // Define other methods and classes here
    public void TestMethod1()
    {	
    	string text = "I want to find the number (30)";
    	var startNumber = text.IndexOf('(');
    	var trimmed = text.Trim(')');
    	var number = trimmed.Substring(startNumber).Trim('(');
    }
    
    public void TestMethod1(string text)
    {
    	var startNumber = text.IndexOf('(');
    	var trimmed = text.Trim(')');
    	var number = trimmed.Substring(startNumber).Trim('(');
    }
    
    public void TestMethod2()
    {
    	string text = "I want to find the number (30)";
    	var lambdaNumber = text.Where(x => Char.IsNumber(x)).ToArray();
    	var joined = string.Join("", lambdaNumber);
    }
    
    public void TestMethod2(string text)
    {	
    	var lambdaNumber = text.Where(x => Char.IsNumber(x)).ToArray();
    	var joined = string.Join("", lambdaNumber);
    }
    
    public void TestMethod3(string text)
    {
    	var regex = new Regex(@"(\d+)");
    	var match = regex.Match(text);
    	var joined = match.Captures[0].Value;
    }
    
    public Regex regex = new Regex(@"(\d+)");
    
    public void TestMethod4(string text)
    {
    	var match = regex.Match(text);
    	var joined = match.Captures[0].Value;
    }
