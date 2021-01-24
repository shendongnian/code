        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string catval = DropDownList1.SelectedValue;
            string qry = "select * from category_sub where parent_id = " +  catval;
            DataTable dt = dbconnection.ExecuteSelect(qry);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "cat_nm";
            DropDownList2.DataValueField = "cat_sub";
            DropDownList2.DataBind();
        }
