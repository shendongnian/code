    public static IMyInterface GetMatchingClass(string className)
        {
            Type t = Type.GetType(pattern);
            return (IMyInterface)Activator.CreateInstance(t);
        }
