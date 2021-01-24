    /// <summary>
    /// Get all records to show in the CheckedListBox
    /// </summary>
    /// <returns></returns>
    public DataTable GetAll()
    {
        var dt = new DataTable();
    
        using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
        {
            using (SqlCommand cmd = new SqlCommand { Connection = cn })
            {
                cmd.CommandText = "SELECT id, Description, Quantity, CheckedStatus FROM Products ---WHERE (Quantity > 0)";
    
                cn.Open();
                dt.Load(cmd.ExecuteReader());
    
            }
        }
    
        return dt;
    
    }
