    protected void JQGrid1_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
            {            
                DataTable dt = GetData();
                dt.PrimaryKey = new DataColumn[] { dt.Columns["CustomerID"] };
                DataRow rowToDelete = dt.Rows.Find(e.RowKey);
    
                if (rowToDelete != null)
    {
                    dt.Rows.Remove(rowToDelete);
    		// store your CustomerID in variable
    		string CustomerId = rowToDelete[0].ToString();//Datatype base on your sql table column
    		SqlConnection sqlConnection = new SqlConnection();
                    sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["SQL2008_661086_trirandEntities"].ConnectionString;
                    sqlConnection.Open();
    
                    string sqlStatement = "delete FROM Customers where CustomerID = "+ CustomerId +"";
    
                    SqlCommand cmd = new SqlCommand(sqlStatement , sqlConnection);
    		cmd.ExecuteNonQuery();
    
    
    }
    
                JQGrid1.DataSource = GetData();
                JQGrid1.DataBind();
    }
