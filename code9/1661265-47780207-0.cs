    protected void doDataTable(string command, int e)
    {
        DataTable dt = new DataTable(); 
        
        dt.Columns.Add("no", typeof(string));
        dt.Columns.Add("desc", typeof(string));
        dt.Columns.Add("code", typeof(string));
        dt.Columns.Add("measure", typeof(string));
        dt.Columns.Add("qty", typeof(int));
        dt.Columns.Add("price", typeof(double));
        foreach (DataListItem item in DataList4.Items) 
        {
            string no = ((TextBox)item.FindControl("no")).Text;
            string desc = ((TextBox)item.FindControl("desc")).Text;
            string code = ((TextBox)item.FindControl("code")).Text;
            string measure = ((TextBox)item.FindControl("measure")).Text;
            int qty = Convert.ToInt16(((TextBox)item.FindControl("qty")).Text);
            double price = Convert.ToDouble(((TextBox)item.FindControl("price")).Text.TrimStart('$'));
            dt.Rows.Add(no, desc, code, measure, qty, price);
        }
        if (command == "add")
        {
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            DataList4.DataSource = dt;
            DataList4.DataBind();
        }
        else if (command == "del")
        {
            dt.Rows[e].Delete();
            DataList4.DataSource = dt;
            DataList4.DataBind();                   
        }
    }
