    public static string ToStr(object readField)
    {
        if ((readField != null))
        {
            if (readField.GetType() != typeof(System.DBNull))
            {
                return Convert.ToString(readField);
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }
