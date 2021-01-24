    using (SqlConnection conn = new SqlConnection(dbConn))
    {
    
    	using (SqlCommand cmd = new SqlCommand())
    	{
    		string sqlString = string.Empty;
    		if (txtSearchVehicleNo.MaskCompleted)
    		{
    			sqlString = "Select * From Master Where VehiNo = @VehiNo;";
    			cmd.Parameters.AddWithValue("@VehiNo", txtSearchVehicleNo.Text);
    		}
    		else if (!string.IsNullOrWhiteSpace(txtSearchMemberName.Text))
    		{
    			sqlString = "Select * From Master Where CustName = @CustName;";
    			cmd.Parameters.AddWithValue("@CustName", txtSearchMemberName.Text);
    		}
    
    		cmd.Connection = conn;
    		cmd.CommandText = sqlString;
    
    		cmd.CommandType = CommandType.Text;
    		conn.Open();
    		SqlDataReader reader = cmd.ExecuteReader();
    		dtMember.Load(reader);
    	}
    }
