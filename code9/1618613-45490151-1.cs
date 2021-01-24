    partial class A
    {
    	partial void OnSomethingHappened(string s);
    	partial void useRef(ref string s);
    	partial void useOpt(string s1, string s2 = null);
    	partial void useArgs(params string [] s);
    }
    
    // This part can be in a separate file.
    partial class A
    {
    	// Comment out this method and the program
    	// will still compile.
    	partial void OnSomethingHappened(String s)
    	{
    		Console.WriteLine("Something happened: {0}", s);
    	}
    }
