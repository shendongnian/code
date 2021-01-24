    private static String InternalFormat(RuntimeType eT, Object value)
    {
        if (!eT.IsDefined(typeof(System.FlagsAttribute), false)) // Not marked with Flags attribute
        {
            // Try to see if its one of the enum values, then we return a String back else the value
            String retval = GetName(eT, value);
            if (retval == null)
                return value.ToString();
            else
                return retval;
        }
        else // These are flags OR'ed together (We treat everything as unsigned types)
        {
            return InternalFlagsFormat(eT, value);
        }
    }
