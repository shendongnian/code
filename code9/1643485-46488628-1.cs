    public Dictionary<string, float> Preview(PreviewDTO prev)
    {
    	Console.WriteLine("{ 0}.{ 1}.{ 2}", prev.id, prev.choice, prev.userDate);
    	Dictionary<string, float> test = new Dictionary<string, float>();
    	test.Add("2017-05-04 10:10:10", 100000);
    	test.Add("2017-05-05 10:10:10", 100001);
    	return test;
    }
