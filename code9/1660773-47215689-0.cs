            public DataSet getCustomers()
        {
            try
            {
                string Connectionstring = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
                SqlConnection objConnection = new SqlConnection(Connectionstring);
                objConnection.Open();
                SqlCommand objCommand = new SqlCommand("Select * from Customer '",
                                                      objConnection);
                DataSet objDataSet = new DataSet();
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);
                objConnection.Close();
                return objDataSet;
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
                return null;
            }
        }
