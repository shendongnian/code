    public static void insertMultipleData()
    {
        string connectionString = "yourConnectionString";
        string insertQuery = "INSERT INTO molasses_analysis(mo_entry_date, mo_entry_time, mo_code, mo_brix, mo_pol, mo_purity, mo_crtd_by) VALUES(@entry_date, @entry_time, @mol_code, @brix, @pol, @purity, @crtd_by)";
    
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(insertQuery, connection))
        {
            // define your parameter's type
            command.Parameters.Add("@entry_date", SqlDbType.YourPropertyType);
            command.Parameters.Add("@entry_time", SqlDbType.YourPropertyType);
            command.Parameters.Add("@mol_code", SqlDbType.YourPropertyType);
            command.Parameters.Add("@brix", SqlDbType.YourPropertyType);
            command.Parameters.Add("@pol", SqlDbType.YourPropertyType);
            command.Parameters.Add("@purity", SqlDbType.YourPropertyType);
            command.Parameters.Add("@crtd_by", SqlDbType.YourPropertyType);
    
            connection.Open();
    
            for (int i = 0; i < yourList.Count; i++)
            {
                //SET the values
    			command.Parameters["@entry_date"].Value = list[0].entry_date;
    			command.Parameters["@entry_time"].Value = list[0].entry_time;
    			command.Parameters["@mol_code"].Value = list[0].mol_code;
    			command.Parameters["@brix"].Value = list[0].brix;
    			command.Parameters["@pol"].Value = list[0].pol;
    			command.Parameters["@purity"].Value = list[0].purity;
    			command.Parameters["@crtd_by"].Value = list[0].crtd_by;
    
                command.ExecuteNonQuery();
            }
        }
    }
