    con.Open();
    ...
    string userid = null;
    string sender;
    string message;
    string date;
    const string sql = 
       "select * from vms2.vms_notification where user = @username;";
    using (var cmd = new MySqlCommand(sql, con))
    {
       cmd.Parameters.AddWithValue("@username", username); 
       var rdr = cmd.ExecuteReader();
       while (rdr.Read())
       {
          userid = (rdr["user"].ToString());
          sender = (rdr["sender"].ToString());
          message = (rdr["message"].ToString());
          date = (rdr["date"].ToString());
       }
    }
