    public static IPrint GetPrint<T>() where T : IPrint, new ()
    {
        foreach (var key in prints.Keys) {
            if (key is T)
        	    return null;
        }
               return new T();
    }
