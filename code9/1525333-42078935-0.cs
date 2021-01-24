    public static void func(ref string str, string replacement)
    {
        if (!String.IsNullOrWhiteSpace(replacement)) {
            str = replacement;
        }
        else
        {
            if(str == null)
              str = "";
        }
    }
