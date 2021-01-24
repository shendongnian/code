    class Program
    {
    	[DllImport("goDLL.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
    	public static extern int PrintHello2([In] byte[] data, ref IntPtr output);
    
    	[DllImport("goDLL.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
    	public static extern IntPtr PrintHello4(byte[] data);
    
    	static void Main(string[] args)
    	{
    		string res = "demo";
    		IntPtr output= IntPtr.Zero;
    		var a = PrintHello4(Encoding.UTF8.GetBytes(res));
    		
    		Console.WriteLine("PrintHello4 Returns: " + Marshal.PtrToStringAnsi(a));
    
    		Console.WriteLine("PrintHello2 Returns: " + PrintHello2(Encoding.UTF8.GetBytes(res), ref output));
    		Console.WriteLine("Ref Val changed to: " + Marshal.PtrToStringAnsi(output) + "\n");
    	}
    }
