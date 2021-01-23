        string[] names = selectedColumns.Split(',');
        sda.Fill(ds);
        for (int i = 0; i < names.Length; i++)
        {
            ds.Tables[0].Columns[names[i]].SetOrdinal(i);`
        }
        ASPxGridView1.DataSource = ds;
        ASPxGridView1.DataBind();
