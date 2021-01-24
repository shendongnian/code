    public static bool NullCheck(params object[] parameters)
    {
        foreach (object parameter in parameters)
            if (parameter == null)
                return false;
        return true;
    }
    public static bool MinCheck(int minimum, params int[] parameters)
    {
        foreach (int parameter in parameters)
            if (parameter < minimum)
                return false;
        return true;
    }
    public static bool MaxCheck(int maximum, params int[] parameters)
    {
        foreach (int parameter in parameters)
            if (parameter > maximum)
                return false;
        return true;
    }
