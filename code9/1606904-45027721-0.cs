    string queryAdd4 = "INSERT INTO [inventory]([item_id],[item_qty],[item_date],[item_type]) VALUES(@myID,@myQty,@myDate,@myType)";
    using (SqlCommand cmd = new SqlCommand(queryAdd4, Con))
    {
    cmd.Parameters.Add(new SqlParameter("@myID", item_id));
    var parameter = new SqlParameter()
    parameter.ParameterName = "@myQty";
    parameter.SqlDbType = SqlDbType.Int;
    parameter.Direction = ParameterDirection.Input;
    parameter.Value = 0;
    cmd.Parameters.Add(parameter);
    cmd.Parameters.Add(new SqlParameter("@myDate", dateNow));
    cmd.Parameters.Add(new SqlParameter("@myType", 1));
    Con.Open();
    cmd.ExecuteNonQuery();
    Con.Close();
