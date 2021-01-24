    void Main()
    {
    	var t = new test();
    	t.boxme = 1;
    	object box = t.boxme;
    	t.boxme = 2;
    	Console.WriteLine(box); // outputs 1
    }
    class test
    {
    	public int boxme;
    }
