	public class MyTraceListener : TraceListener
	{
        // called (in debug-mode) when Debug.Write() is called
		public override void Write(string message)
		{
            // handle/output "message" properly
		}
        // called (in debug-mode) when Debug.WriteLine() is called
		public override void WriteLine(string message)
		{
            // handle/output "message" properly
		}
	}
