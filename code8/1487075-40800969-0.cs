     protected void bremove_Click(object sender, EventArgs e)
        {
            int index = DataList1.SelectedIndex;
            DataTable dt = Session["AddToCard"] as DataTable;
            dt.Rows[index].Delete();
            porductlist = dt;
            Session["AddToCard"]= dt
            BindData();
            Response.Redirect("Default.aspx");
        }
     public void BindData()
        {
            DataList1.DataSource = porductlist;
            DataList1.DataBind();
        }
