    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			var form = new Form();
    			Trace.WriteLine(SynchronizationContext.Current?.GetType().ToString() ?? "null");
    			form.ShowDialog();
    			Trace.WriteLine(SynchronizationContext.Current?.GetType().ToString() ?? "null");
    		}
    	}
    }
