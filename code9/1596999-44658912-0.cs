    [ContractAnnotation(toCheck:notnull => true]
    public static bool Exists(this object toCheck)
    {
       return toCheck != null;
    }
