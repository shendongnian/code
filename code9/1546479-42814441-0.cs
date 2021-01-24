    public static bool Equals(Object objA, Object objB)
    {
        if (objA == objB)
        {
            return true;
        }
        if (objA == null || objB == null)
        {
            return false;
        }
        return objA.Equals(objB);
    }
