    private string FormatValue (object value)
    {
        //You can amend this check to another numeric type or add others
        if (value is int)
        {
            return string.Format("{0:n1}", value);
        }
        else
        {
            throw new System.ArgumentException("object not an integer", value);
        }
    }
        
