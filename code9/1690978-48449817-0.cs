    public DataTable CreateTable()
            {
                var dt = new DataTable();
                dt.Columns.Add("Label", typeof(string));
                dt.Columns.Add("Value", typeof(string));
                return dt;
            } 
    public postdata(formdata){
    var myDataTable = CreateTable();
                foreach (var dataField in formData.PostedFields)
                {
                    myDataTable.Rows.Add(dataField.Label, dataField.Value);
                }
    
     using (var cnn = new SqlConnection(connectionString))
                {
                    var cmd = cnn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "WebFormTask";
                   SqlParameter param = cmd.Parameters.AddWithValue("@PostedFields", myDataTable);
                                   cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
    }
