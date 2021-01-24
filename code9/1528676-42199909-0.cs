    public static bool IsJobClass(Type type)
    {
        if (type == null)
        {
            return false;
        }
        return type.IsClass
            // For C# static keyword classes, IsAbstract and IsSealed both return true. Include C# static keyword
            // classes but not C# abstract keyword classes.
            && (!type.IsAbstract || type.IsSealed)
            // We only consider public top-level classes as job classes. IsPublic returns false for nested classes,
            // regardless of visibility modifiers. 
            && type.IsPublic
            && !type.ContainsGenericParameters;
    }
