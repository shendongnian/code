    using System.Threading;
    using System.Management.Automation.Runspaces;
    // ...
    
    Runspace rs = RunspaceFactory.CreateRunspace();
    rs.ApartmentState = ApartmentState.STA;
