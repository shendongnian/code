    public static object GetPlcValue(int pItem)
    {
        object lclObject = new object();
        globalOpcItem[pItem].Read(1, lclObject);
    }
