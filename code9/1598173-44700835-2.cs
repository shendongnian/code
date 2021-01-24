    public void Insert(List<CheckListBoxItem> items)
    {
        // optionally used for obtaining new primary key
        //int newIdentifier;
    
        using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
        {
            using (SqlCommand cmd = new SqlCommand { Connection = cn })
            {
                // uncomment ending select statement and use commented to get new primary key
                cmd.CommandText = "INSERT INTO Products " + 
                    "([Description],Quantity,CheckedStatus) " + 
                    "VALUES (@Description,@Quantity,@CheckedStatus); " + 
                    "-- SELECT CAST(scope_identity() AS int);";
    
                cmd.Parameters.Add(new SqlParameter()
                    { ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar });
                cmd.Parameters.Add(new SqlParameter()
                    { ParameterName = "@Quantity", SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter()
                    { ParameterName = "@CheckedStatus", SqlDbType = SqlDbType.Bit });
                cmd.Parameters.Add(new SqlParameter()
                    { ParameterName = "@CategoryIdentifier", SqlDbType = SqlDbType.Int });
    
    
                cn.Open();
    
                foreach (CheckListBoxItem item in items)
                {
                    cmd.Parameters["@Description"].Value = item.Description;
                    cmd.Parameters["@Quantity"].Value = item.Quantity;
                    cmd.Parameters["@CheckedStatus"].Value = item.Checked;
    
                            
                    //newIdentifier = (int)cmd.ExecuteNonQuery();
                    if ((int)cmd.ExecuteNonQuery() > -1)
                    {
                        // inserted
                    }
                    else
                    {
                        // failed
                    }
    
                }
            }
        }
    }
