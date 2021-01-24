    public static object GetPlcValue(string pItem)
    {
        object lclObject = new object();
        globalOpcItem[int.Parse(pItem)].Read(1, lclObject);
    }
