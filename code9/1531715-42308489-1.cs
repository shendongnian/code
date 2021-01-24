    <Columns>   
        <FooterTemplate>
        <asp:LinkButton ID="btnAddNew" Text="Add New" runat="server" CommandName="AddNew" ToolTip="ADD"/>
        </FooterTemplate>
        </asp:TemplateField>
    </Columns> 
	protected void EmpGrid_Command(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName.Equals("AddNew"))
		{
			TextBox txtf = (TextBox)EmpGrid.FooterRow.FindControl("txtFooterFname");
			TextBox txtl = (TextBox)EmpGrid.FooterRow.FindControl("txtfooterLname");
			TextBox txtq = 
					(TextBox)EmpGrid.FooterRow.FindControl("txtfooterqualification");
			TextBox txtd = 
					(TextBox)EmpGrid.FooterRow.FindControl("txtfooterdecription");
			TextBox txts = (TextBox)EmpGrid.FooterRow.FindControl("txtfootersalary");
            // For Inserting New Row
			string insrtquery = "insert into EMPTable
								(fname,lname,qualification,designation,sal) values
								('" + txtf.Text + "','" + txtl.Text + "',
								 '" + txtq.Text + "','" + txtd.Text + "','" +
									  txts.Text + "')";
			da = new SqlDataAdapter(insrtquery, con);
			DataSet ds = new DataSet();
			da.Fill(ds,"inserted");
			Bindemployees();
		 }       
	}
    protected void EmpGrid_Updating(object sender, GridViewUpdateEventArgs e)
    {
    int empid = Convert.ToInt32(EmpGrid.DataKeys[e.RowIndex].Value.ToString());
    string fname = EmpGrid.DataKeys[e.RowIndex].Values["fname"].ToString();
    string lname = EmpGrid.DataKeys[e.RowIndex].Values["lname"].ToString();
    TextBox txtq = 
           (TextBox)EmpGrid.Rows[e.RowIndex].FindControl("txtEditqualification");
    TextBox txtd = 
           (TextBox)EmpGrid.Rows[e.RowIndex].FindControl("txtEditdesignation");
    TextBox txts = 
           (TextBox)EmpGrid.Rows[e.RowIndex].FindControl("txtEditsalary");
    string updatequery = "update EMPTable set qualification='" + txtq.Text +
                       "',designation='" + txtd.Text + "',sal='" + txts.Text + "'
                       where empid='" + empid + "'";
    DataSet ds = new DataSet();
    da = new SqlDataAdapter(updatequery,con);
    da.Fill(ds,"added");
    EmpGrid.EditIndex = -1;
    Bindemployees();
    }
    protected void EmpGrid_Deleting(object sender, GridViewDeleteEventArgs e)
    {
    int empid = Convert.ToInt32(EmpGrid.DataKeys[e.RowIndex].Value.ToString());
    da = new 
    SqlDataAdapter("delete from EMPTable where empid='" + empid + "'", con);
    DataSet ds = new DataSet();
    da.Fill(ds,"deleted");
    Bindemployees();
    }
