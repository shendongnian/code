    public void CreateMessage(int profileId, String text, int chatId)
        {
            string stmt = "INSERT INTO Activity (profileID, timeStamp) OUTPUT INSERTED.activityID values (" + profileId + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')";
            SqlDataReader reader = new SqlCommand(stmt, con).ExecuteReader();
            reader.Read();
    
            stmt = "INSERT INTO Text(activityID, message) OUTPUT INSERTED.textID values(" + Int32.Parse(reader["activityID"].ToString()) + ", (select cast('" + text + "' as varbinary(max))))";
            reader.Close();
            reader = new SqlCommand(stmt, con).ExecuteReader();
            reader.Read();
    
            stmt = "INSERT INTO Message (textID, chatID) values (" + Int32.Parse(reader["textID"].ToString()) + ", " + chatId + ")";
            reader.Close();
            new SqlCommand(stmt, con).ExecuteNonQuery();
        }
