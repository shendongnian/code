    static void Main(string[] startArgs)
    {
    	if (startArgs.Length == 0)
    	{
    		//show messagebox stating that there's no parameters or something else
    	}
    	else
    	{
    		var configArg = startArgs.FirstOrDefault(s => s.StartsWith("config"));
    		if (configArg == null)
    		{
    			//config parameter is missing
    		}
    		else
    		{
    			string xml = configArg.Split('=')[1];
    			//xml holds your path to your xml file. 
                //Now you can pass it to form, or load it here
    			 
    			//XmlDocument doc = new XmlDocument();
    			//doc.Load(xml);
    			//etc...
    		}
    
    	}
    		
    	Application.EnableVisualStyles();
    	Application.SetCompatibleTextRenderingDefault(false);
    	Application.Run(new Form1());
    }
