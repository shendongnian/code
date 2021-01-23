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
    var domain = AppDomain.CreateDomain("SomeGenericName", null, adSetup, permission, null); // sandboxed AppDomain
    try
    {
        Helper helper = (Helper)domain.CreateInstanceAndUnwrap(typeof(Helper).Assembly.FullName, typeof(Helper).FullName);
        // create an instance of Helper in the new AppDomain
        helper.LoadAssembly(bytes); // bytes is the in-memory assembly
    }
    catch (TargetInvocationException e) when (e.InnerException.GetType() == typeof(SecurityException))
    {
        Console.WriteLine("some kind of permissions issue here");
    }
    catch (Exception e)
    {
        Console.WriteLine("Something else failed in ConsoleApplication1.exe's main... " + e.Message);
    }
