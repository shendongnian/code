    var parameters = string.Join(",",DataValues.Select((x,i)=>"@param"+i));
    var myInsert = string.Format("Insert into table1({0}) values ({1})", columns, parameters);
    using (SqlConnection connection = new SqlConnection(/* connection info */))
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
        for(var i=0; i< DataValues.Length ; i++)
        {
            command.Parameters.AddWithValue("@param"+i,DataValues[i]);
        }
        command.ExecuteNonQuery();
    }
