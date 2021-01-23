    string sqlFormattedDate = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss.fff");
    db.Cmd = db.Conn.CreateCommand();
    db.Cmd.CommandText = "SELECT RoomNumber FROM RoomTBL WHERE RoomNumber NOT IN (SELECT RoomNumber FROM LessonsTBL Where PupilID = " + 1 + " AND StartDate = '" + sqlFormattedDate + "')";
    //db.Cmd.ExecuteNonQuery();
    db.Rdr = cmd.ExecuteReader()
    if (db.Rdr.HasRows)
    {
      while (db.Rdr.Read())
      {
        listBox1.Items.Add(db.Rdr);
      }
    }   
    db.Rdr.Close();
