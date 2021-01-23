    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        string sColumn = "Name";
        string sFind = "John";
        foreach (PropertyInfo p in Row.GetType().GetProperties())
        {
            string sval;
            if (p.Name.ToString() == sColumn)
            {
                sval = p.GetValue(Row, null).ToString();
                if (sval != sFind) 
                {
                    //Do Stuff
                }
            }
            
        }
    }
