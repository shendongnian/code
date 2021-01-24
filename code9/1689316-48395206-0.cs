    var queryWithForJson = "SELECT ... FOR JSON";
    var conn = new SqlConnection("<connection string>");
    var cmd = new SqlCommand(queryWithForJson, conn);
    conn.Open();
    var jsonResult = new StringBuilder();
    var reader = cmd.ExecuteReader();
    if (!reader.HasRows)
    {
        jsonResult.Append("[]");
    }
    else
    {
        while (reader.Read())
        {
            jsonResult.Append(reader.GetValue(0).ToString());
        }
    }
