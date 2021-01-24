    string strQuery = "Delete from [AirlineTicketReservation].[dbo].[Traveller_Info] Where CNIC = @CNIC";      
    using(SqlCommand cmd = new SqlCommand(strQuery, conn))
    {
       cmd.Parameters.Add("@CNIC", SqlDbType.Varchar).Value = mtxtCNIC.Text;
       int rowsAffected = cmd.ExecuteNonQuery();
       if(rowsAffected > 0)
       {
           MessageBox.Show("Account has been deleted.");
       }
       else
       {
           MessageBox.Show("Please Recheck the CNIC, it is not existing", "Failed");
       }
    }
