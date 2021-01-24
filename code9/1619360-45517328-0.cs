    for (int i = bd.NameList.Count-1; i>=0; i--)
    {
        bData = bd.NameList[i];
        Object[] param = new Object[2];
        param[0] = bData.m_Width;
        param[1] = bData.m_Height;
        DataGrid1.Rows.Insert(0, param);
    }
