    foreach (BD bData in bl.NameList)
    {
        Object[] param = new Object[2];
        param[0] = bData.m_Width;
        param[1] = bData.m_Height;
        DataGrid1.Rows.Add(param);
    }
