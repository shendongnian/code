    void Main()
    {
	SomeClass x = new SomeClass();
	x.WriteTestLog();
	
	int i = 1;
	i.LogMsg("abc");
    }
    public static class Logger
    {
      public static void LogMsg(this object objectCalling, string msg)
      {
          Print(objectCalling.GetType().Name + ": " + msg);
      }
      private static void Print(string msg)
      {
        Console.WriteLine(msg);  // print it
      } 
    }
    public class SomeClass
    {
      public void WriteTestLog()
      {
        this.LogMsg("Testing!");
      }
    }
