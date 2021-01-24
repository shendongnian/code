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
