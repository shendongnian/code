    RDotNet.StartupParameter sp = new StartupParameter();
    sp.Interactive = false;
    sp.Quiet = false;
    MyCharacterDevice ic = new MyCharacterDevice();
    REngine.SetEnvironmentVariables(Rpath);
    REngine engine = REngine.GetInstance("", true, sp, ic);
    
    if (engine.IsRunning == false)
    {
        engine.Initialize(sp, ic, true);
    }
    
    //engine.Evaluate code...
    
    string rConsoleMessages = ic.sb.ToString();
