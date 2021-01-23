    [RuleCombinationOfPropertiesIsUnique("RoleUniqueName", DefaultContexts.Save, "Name")]
    public class MyRole : Role {   
        public MyRole(Session session) : base(session) { }
        // etc...   
    }
