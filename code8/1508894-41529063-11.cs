    AppDomainSetup adSetup = new AppDomainSetup();
    adSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
    // This is where the main executable resides. For more info on this, see "Remarks" in
    // https://msdn.microsoft.com/en-us/library/system.appdomainsetup.applicationbase(v=vs.110).aspx#Anchor_1
    PermissionSet permission = new PermissionSet(PermissionState.None);
    // Permissions of the AppDomain/what it can do
    permission.AddPermission(new SecurityPermission(SecurityPermissionFlag.AllFlags & ~SecurityPermissionFlag.UnmanagedCode));
    // All SecurityPermission flags EXCEPT UnmanagedCode, which is required by Environment.Exit()
    // BUT the assembly needs SecurityPermissionFlag.Execution to be run;
    // otherwise you'll get an exception.
    permission.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
    permission.AddPermission(new UIPermission(PermissionState.Unrestricted));
    // the above two are for Console.WriteLine() to run, which is what I had in the Main method
    var assembly = Assembly.LoadFile(exePath); // path to ConsoleApplication1.exe
    var domain = AppDomain.CreateDomain("SomeGenericName", null, adSetup, permission, null); // sandboxed AppDomain
            
    try
    {
        domain.ExecuteAssemblyByName(assembly.GetName(), new string[] { });
    }
    // The SecurityException is thrown by Environment.Exit() not being able to run
    catch (SecurityException e) when (e.TargetSite == typeof(Environment).GetMethod("Exit"))
    {
        Console.WriteLine("Tried to run Exit");
    }
    catch (SecurityException e)
    {
        // Some other action in your method needs SecurityPermissionFlag.UnmanagedCode to run,
        // or the PermissionSet is missing some other permission
    }
    catch
    {
        Console.WriteLine("Something else failed in ConsoleApplication1.exe's main...");
    }
