    static class Program
    {
    	static void Main()
    	{
    		int[] test = { 1, 12, 13, 11, 31, 41, 21};
    		test.CycleArray();
    	}
    	public static void CycleArray(this int[] myArr)
    	{
    		if (myArr.Length > 0)
    			foreach (int x in myArr)
    				Console.WriteLine(x);
    	}
