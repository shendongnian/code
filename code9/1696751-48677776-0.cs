    updatequery = @"UPDATE EMP_DETAILS 
                    SET ADVANCE_SAL = ADVANCE_SAL + @ADVANCE_SAL
                    WHERE EMP_ID = @EMP_ID"
    
    using (SqlConnection connection = new SqlConnection(/* connection info */))
    {
        using (SqlCommand command = new SqlCommand(updatequery , connection))
        {
            // must do proper error handling
            connection.Open();
            command.Parameters.Add(new SqlParameter("ADVANCE_SAL", Convert.ToDecimal(txtADV.Text)));
            command.Parameters.Add(new SqlParameter("EMP_ID", Convert.ToInt64(txtEID.Text)));
            int results = command.ExecuteNonQuery();
        }
    }
