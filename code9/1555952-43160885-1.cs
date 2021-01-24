    protected void btn_click(object sender, EventArgs e)
    {
       //*Here You'll have to put your Own Logic. I've bided datalist just for example.*
        DataTable dt = new DataTable();
        dt.Columns.Add("Comments");
        dt.Rows.Add("abc");
        dlist.DataSource = dt;
        dlist.DataBind();
    }
