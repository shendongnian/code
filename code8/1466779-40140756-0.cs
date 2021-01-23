    void Main()
    {
	var t = new System.Threading.Timer((s)=>Console.WriteLine("Hi"),null,0,60000);
	Console.ReadLine();
    }
