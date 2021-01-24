    public static IMyInterface GetMatchingClass(string className)
        {
            Type t = Type.GetType(className);
            return (IMyInterface)Activator.CreateInstance(t);
        }
