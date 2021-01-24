        public void CreateMessage(int profileId, String text, int chatId)
            {
                string stmt = "INSERT INTO Activity (profileID, timeStamp) OUTPUT INSERTED.activityID values (" + profileId + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "');
    INSERT INTO Message (textID, chatID) values (" + Int32.Parse(reader["textID"].ToString()) + ", " + chatId + ");
    INSERT INTO Text(activityID, message) OUTPUT INSERTED.textID values(" + Int32.Parse(reader["activityID"].ToString()) + ", (select cast('" + text + "' as varbinary(max))))";
                SqlDataReader reader = new SqlCommand(stmt, con).ExecuteReader();
                reader.Read();
            }
