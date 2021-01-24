    //using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    
    public static class SomeClass
    {
    
    	public static void SomeMethod()
    	{
    		Threading.Thread t = new Threading.Thread(() =>
    		{
    			try {
    				while (true) {
    					dynamic server = new NamedPipeServerStream("Closer", PipeDirection.InOut, -1);
    					server.WaitForConnection();
    					if (!server.IsConnected)
    						return;
    					dynamic reader = new IO.StreamReader(server);
    					dynamic casetxt = reader.ReadToEnd();
    					server.Close();
    					RootForm.Invoke(() =>
    					{
    						if (casetxt == "End") {
    							System.Environment.Exit(0);
    						}
    					});
    				}
    			} catch (Exception ex) {
    				// try/catch required in all child threads as error silently ends app.
    				// log it... 
    			}
    		});
    		t.IsBackground = true;
    		t.Name = "EnderListener";
    		t.Start();
    	}
    }
    
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
