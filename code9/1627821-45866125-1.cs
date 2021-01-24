    public string Translate(object value)
    {
        if (value is int)
        {
            int intVal = (int) value;
            switch (intVal)
            {
                case db1:
                    return "Diabetes Type 1";
                //etc
            }
        }
        return "";
    }
