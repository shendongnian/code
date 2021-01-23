    public Dictionary<String, Object> staffInfo(string field, string Username)
    {
        string chk_PR = this.Is_PR_Staff(Username) == true ? BW_Config.default_postroom_staff : "";
        string strDBConn = db.getDBstring(Globals.booDebug);
        SqlConnection conn = new SqlConnection(strDBConn);
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "SELECT " + field + " FROM BW_GetStaffInfo('" + Username + "', '" + chk_PR + "')";
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                Dictionary<String, Object> row = new Dictionary<String, Object>;
                Object obj = nothing;
                for (i = 0; i < reader.FieldCount; i++){
                    obj = reader.GetValue(i);
                    if (IsDBNull(obj)){
                        obj = "";
                    }
                    row.add(reader.GetName(i), obj);
                }
                return row;
            }
            else
            {
                return null;
            }
        }
    }
