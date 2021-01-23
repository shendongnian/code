    using (MySqlDataReader rdr = cmd.ExecuteReader())
    {
        if (rdr.Read())
        {
            ext = rdr.GetString(2);
            using (MemoryStream ms = new MemoryStream((byte[])rdr["imgData"]))
            {
                picBox.Image = Image.FromStream(ms);
            }
        }
    }
