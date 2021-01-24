    private static Func<object, bool> cachedT;
    public Test()
    {
        if (cachedT == null)
        {
            cachedT = _ => true;
        }
        Func<object, bool> t = cachedT;
    }
