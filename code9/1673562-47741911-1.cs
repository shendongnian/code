    public static IPolicy CreatePolicy(Policy policy)
    {
        //Change this if the namespace of your classes differs
        string ns = typeof(Policy).Namespace;
        string typeName = ns + "." + policy.ToString();
        return (IPolicy)Activator.CreateInstance(Type.GetType(typeName));
    }
