    using System.Collections.ObjectModel;
    using System.IO;
    using System.Management.Automation;
    //...
    
    using(PowerShell ps = PowerShell.Create())
    {
        ps.AddScript(Path.Combine(Config.Directory, "ICS.ps1"))
            .AddParameter("toggle", toggle)
            .AddParameter("par1", par1)
            .AddParameter("par2", par2)
            .AddParameter("connectionInterface", connectionInterface);
        Collection<PSObject> results = ps.Invoke();
    }
