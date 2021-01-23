    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
	if (e.Row.RowType == DataControlRowType.DataRow)
	{
		var ddl = (DropDownList)e.Row.FindControl("EqpCatDDL'");
		SqlCommand cmd = new SqlCommand("SELECT EqpCateID, EqpCat FROM EqpCategory", connection);
		SqlDataAdapter da = new SqlDataAdapter(cmd);
		DataSet ds = new DataSet();
		da.Fill(ds);
		EqpCatDDL.DataSource = ds;
		EqpCatDDL.DataValueField = "EqpCateID";
		EqpCatDDL.DataTextField = "EqpCat";
		EqpCatDDL.DataBind();
	}
    }
