    // Assign the application name to a variable
    var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
    // If under debug replace it with the debug name
    #if DEBUG
    appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".vshost.exe";
    #endif 
    // Your registry code
    ...
    if (Key.GetValue(appName) == null)
      Key.SetValue(appName, RegVal, RegistryValueKind.DWord);
