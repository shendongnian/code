     **I hope you looking for something like this**
     protected void BindGridview1()
    {
        DataTable dtt = new DataTable();
        DataTable dt = (DataTable)Session["od"];
        dtt.Columns.Add("BookingNO", typeof(string));
        dtt.Columns.Add("ItemName", typeof(string));
        dtt.Columns.Add("Size", typeof(string));
        dtt.Columns.Add("Unit", typeof(string));
        dtt.Columns.Add("Price", typeof(string));
        dtt.Columns.Add("PendingQty", typeof(string));
        for (int i = 0; i < dtt.Rows.Count; i++)
        {
            DataRow dr = dtt.NewRow();
            dr["BookingNO"] = string.Empty;
            dr["ItemName"] = string.Empty;
            dr["Size"] = string.Empty;
            dr["Unit"] = string.Empty;
            dr["Price"] = string.Empty;
            dr["PendingQty"] = string.Empty;
            dtt.Rows.Add(dr);
        }
        dtt = dt;
        gvDetails.DataSource = dtt;
        gvDetails.DataBind();
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            TextBox BookingNO = (TextBox)gvDetails.Rows[i].FindControl("BookingNO");
            TextBox ItemName = (TextBox)gvDetails.Rows[i].FindControl("ItemName");
            TextBox Size = (TextBox)gvDetails.Rows[i].FindControl("Size");
            TextBox Unit = (TextBox)gvDetails.Rows[i].FindControl("Unit");
            TextBox Price = (TextBox)gvDetails.Rows[i].FindControl("Price");
            //TextBox DueDate = (TextBox)gvDetails.Rows[i].FindControl("DueDate");
            TextBox PendingQty = (TextBox)gvDetails.Rows[i].FindControl("PendingQty");
            BookingNO.Text = Session["BookingNO1"].ToString();
            ItemName.Text = dt.Rows[i]["ItemName"].ToString();
            Size.Text = dt.Rows[i]["Size"].ToString();
            Unit.Text = dt.Rows[i]["Unit"].ToString();
            Price.Text = dt.Rows[i]["Price"].ToString();
            //DueDate.Text = dt.Rows[i]["DueDate"].ToString();
            PendingQty.Text = dt.Rows[i]["PendingQty"].ToString();
        }
    }
