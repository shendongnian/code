	using System.Data;
	using System.Data.SqlClient;
	using (SqlConnection connection = new SqlConnection(connectionString))
	{
	  DataSet userDataset = new DataSet();
	  SqlDataAdapter myDataAdapter = new SqlDataAdapter(
			 "SELECT au_lname, au_fname FROM Authors WHERE au_id = @au_id", 
			 connection);                
	  myDataAdapter.SelectCommand.Parameters.Add("@au_id", SqlDbType.VarChar, 11);
	  myDataAdapter.SelectCommand.Parameters["@au_id"].Value = SSN.Text;
	  myDataAdapter.Fill(userDataset);
	}
