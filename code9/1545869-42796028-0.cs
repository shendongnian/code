    protected void Button1_Click(object sender, EventArgs e)
    {
        //create a datatable
        DataTable table = new DataTable();
        //add one or more colums to the datatable
        table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Text", typeof(string));
        //loop the gridview rows
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (chk.Checked == true)
            {
                string str = GridView1.Rows[i].Cells[1].Text;
                //add a new row to the datatable
                table.Rows.Add(i, str);
            }
        }
    }
