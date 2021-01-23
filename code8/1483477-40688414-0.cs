    private int i;
    private bool isSet;
    public int IProp
    {
        get { return i;}
        set { isSet =true; i=value; }
    }
    // test 
	Console.WriteLine("Is Set:" + isSet);
	IProp = 0;
	Console.WriteLine("Is Set:" + isSet);
    //results
    //Is Set:False
    //Is Set:True
