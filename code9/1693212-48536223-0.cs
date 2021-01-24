        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            BindGridView();
        }
        private void BindGridView()
        {
            DataTable dts = new DataTable();
            dts = (DataTable)ViewState["Receiptdetails"];
            GridView2.DataSource = dts;
            GridView2.DataBind();
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("Receipttypeddl");
                BindDropdown(ddl);
            }
        }
        DataTable ds = new DataTable();
        private void BindDropdown(DropDownList ddl)
        {
            if (ds.Rows.Count == 0)
            {
                SqlDataAdapter da;
                con.Open();
                string qry;
                qry = "select * from ReceiptType";
                SqlCommand cmd = new SqlCommand(qry);
                cmd.Connection = con;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            ddl.DataSource = ds;
            ddl.DataTextField = "Receiptmode";
            ddl.DataValueField = "Receiptmode";
            ddl.DataBind();
            ListItem i = new ListItem("", "");//Data is not inserting into ddl
            ddl.Items.Insert(0, i);
        }
