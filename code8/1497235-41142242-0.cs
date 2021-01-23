    string message = bf.Deserialize(client).ToString();
    SqlCommand com = new SqlCommand("insert into messages (messagetext,sentdate) values (@sqlMessage, @sqlDatetime)", sc);
    com.Parameters.AddWithValue("@sqlMessage", message);
    DateTime myDateTime = DateTime.Now;
    var sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
    com.Parameters.AddWithValue("@sqlDataTime", sqlFormattedDate);
    int success = com.ExecuteNonQuery();
    if (success < 1)
    {
        MessageBox.Show("Something went wrong");
    }
