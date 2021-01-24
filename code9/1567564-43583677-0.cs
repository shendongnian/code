    string add1 = txtAdd1.Text;
    string add2 = txtAdd2.Text;
    if(string.isNullOrEmpty(add1) && add1.Contains("'"))
    {
        add1 = add1.Replace("'", "''");
    }
    if(string.isNullOrEmpty(add2) && add2.Contains("'"))
    {
        add2 = add2.Replace("'", "''");
    }
