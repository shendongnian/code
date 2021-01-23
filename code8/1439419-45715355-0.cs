    SapROTWr.CSapROTWrapper sapROT = new SapROTWr.CSapROTWrapper();
    object objSapGui = sapROT.GetROTEntry("SAPGUI");
    
    object objEngine = objSapGui.GetType().InvokeMember("GetScriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null, objSapGui, null);
    
    for (int x = 0; x < (objEngine as GuiApplication).Children.Count; x++)
    {
        GuiConnection sapConnection = ((objEngine as GuiApplication).Children.ElementAt(x) as GuiConnection);
        string strDescr = (sapConnection.Description);
    }
