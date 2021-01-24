    //css_resource alpha.ico
    
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Reflection;
    
    class Script
    {
    	[STAThread]
    	static public void Main(string[] args)
    	{
    		var assembly = Assembly.GetExecutingAssembly();
    
    		using (var stream = assembly.GetManifestResourceStream("alpha.ico"))
    		{
    			var icon = new Icon(stream);
    		}
    	}
    }
