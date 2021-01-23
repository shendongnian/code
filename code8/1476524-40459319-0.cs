    using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
    
                    if (cnn.State.ToString() == "Closed") cnn.Open();
    
                    SqlCommand cmd = new SqlCommand("viewByCat", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@keywords", SqlDbType.VarChar, 30).Value = Combobox.Text;
    
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Search");
    
                    cnn.Close();
    
                } 
