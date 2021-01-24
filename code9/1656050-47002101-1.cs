    // ConsoleApplication1.Program
    private static void Main(string[] args)
    {
    	string[] list = Enum.GetNames(typeof(UriComponents));
    	string[] array = list;
    	for (int j = 0; j < array.Length; j++)
    	{
    		string item = array[j];
    		Console.WriteLine(item);
    	}
    	for (int i = 0; i < list.Length; i++)
    	{
    		Console.WriteLine(list[i]);
    	}
    	Console.WriteLine(string.Join(Environment.NewLine, list));
    }
