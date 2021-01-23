    public string funcVars(MyValues values)
    {
        string strVars = 
            String.Join(", ", new[] { values.SomeString, 
            values.SomeInt.ToString(), values.SomeBool.ToString() });
        return strVars;
    }
