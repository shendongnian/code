    PrincipalContext pc1 = new PrincipalContext(ContextType.Domain, LDAPusername, LDAPpassword);
    dynamic cp = ComputerPrincipal.FindByIdentity(pc1, "computername");
    dynamic computer = (DirectoryEntry)cp.GetUnderlyingObject();
    string @group = groupdistinguishedname("groupyourwantingtosetasprimary");
    DirectoryEntry groupdirentry = new DirectoryEntry("LDAP://" + @group, LDAPusername, LDAPpassword);
    groupdirentry.Invoke("Add", new object[] { computer.Path });
    groupdirentry.CommitChanges();
    groupdirentry.Invoke("GetInfoEx", new object[] {
    	new object[] { "primaryGroupToken" },
    	0
    });
    object primaryGroupToken = groupdirentry.Invoke("Get", new object[] { "primaryGroupToken" });
    computer.Invoke("Put", new object[] {
    	"primaryGroupID",
    	primaryGroupToken
    });
    computer.CommitChanges();
