    List<int> lstPersonId = new List<int>();
    foreach (DataRow row in ds.Tables[0].Rows)
      {
      lstPersonId.Add(Convert.ToInt32(row["USER_ID"]));
      }
    List<string> lstPersonName = new List<string>();
    foreach (DataRow row in ds.Tables[0].Rows)
      {
      lstPersonName.Add(row["USERNAME"].ToString());
      }
    int[] arrPersonId = lstPersonId.ToArray();
    string[] arrPersonName = lstPersonName.ToArray();
    OracleConnection connection = new OracleConnection();
    connection.ConnectionString = DAKObj.GetOraConnectionString();
    OracleCommand command = new OracleCommand();
    command.Connection = connection;
    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = "sp_InsertByODPNET";
    command.Parameters.Add("@PersonId", OracleDbType.Int32);
    command.Parameters[0].Value = arrPersonId;
    command.Parameters.Add("@PersonName", OracleDbType.Varchar2, 100);
    command.Parameters[1].Value = arrPersonName;
    command.ArrayBindCount = arrPersonId.Length;
    connection.Open();
    command.ExecuteNonQuery();
    connection.Close();
