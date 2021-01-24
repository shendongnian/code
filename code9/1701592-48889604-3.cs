    static void Main(string[] args)
	{
		helper helper = new helper();
		helper.Done += helper_Done;
		helper.Process();
		Console.ReadLine();
	}
	static void helper_Done(object sender, int e)
	{
		Console.WriteLine("Main " + e.ToString());
	}
