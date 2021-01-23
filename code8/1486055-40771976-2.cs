    using System.Security.Principal;
    static string GetUserName()
    {
        WindowsIdentity wi = WindowsIdentity.GetCurrent();
        string[] parts = wi.Name.Split('\\');
        if(parts.Length > 1) //If you are under a domain
            return parts[1];
        else
            return wi.Name;
    }
