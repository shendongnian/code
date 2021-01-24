        PrincipalContext PC = new PrincipalContext(ContextType.Domain);
        UserPrincipal UP = UserPrincipal.FindByIdentity(PC, "testact");
        DirectoryEntry DE = (DirectoryEntry)UP.GetUnderlyingObject();
        //To Change the value
        DE.InvokeSet("TerminalServicesHomeDirectory", new object[] { "testing" });
        //to get the value
        string value = DE.InvokeGet("TerminalServicesHomeDirectory");
