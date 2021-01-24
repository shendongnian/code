    public string Translate(object value)
    {
        //custom logic
        string str = value as string;
        if (str != null)
        {
            switch (str)
            {
                case "db1":
                    return "Diabetes Type 1";
                //etc
            }
        }
        return "";
    }
