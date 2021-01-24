        try
        {                
            conn.Open();
            string strQuery = "Select CNIC from [AirlineTicketReservation].[dbo].[Traveller_Info] Where CNIC = '" + mtxtCNIC.Text + "'";
            string strDeleteQuery = "Select CNIC from [AirlineTicketReservation].[dbo].[Traveller_Info] Where CNIC = '" + mtxtCNIC.Text + "'";
            
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cnic = reader["CNIC"].ToString();
                if (mtxtCNIC.Text == cnic)
                {
                    SqlCommand delCommand = new SqlCommand(strDeleteQuery, conn);
                    delCommand.ExecuteNonQuery();
                    done = true;
                    MessageBox.Show("Account has been deleted.");
                                        break;
                }
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            conn.Close();
        }
        if (!done)
        {
            MessageBox.Show("Please Recheck the CNIC", "Failed");
        }
