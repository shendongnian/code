    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem row in RadGrid1.Items)
        {
            string rowValue = row["ColumnUniqueName"].Text;
        }
    }
