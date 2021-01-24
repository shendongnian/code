    string sAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
    psi.FileName = "mono";
    psi.Arguments = sAppPath + @"/HelloWorld.exe CmdLineArg";
    System.Diagnostics.Process.Start(psi);
}`
