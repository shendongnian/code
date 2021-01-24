    public class testdelegate : IDisposable
    {
    	public delegate void del_copysomething(int newvaluetocopy);
    	internal static del_copysomething dl_myfunctionthatcopy;
    	public int valueforallobject = 0;
    
    	public testdelegate()//ctor
    	{
    		dl_myfunctionthatcopy += new del_copysomething(copythisint);
    	}
    	private void copythisint(int newvalue)
    	{
    		valueforallobject = newvalue;
    		Console.WriteLine("Copied");
    	}
    	
    	public void Dispose()
    	{
    		dl_myfunctionthatcopy -= new del_copysomething(copythisint);
            GC.SuppressFinalize(this);
    	}
    }
