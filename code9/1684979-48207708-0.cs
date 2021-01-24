    public class DeleteAction
    {
        public void DeleteRecord(int id)
        {
            //xxx
            const string ConnStr = "...";
            MySqlConnection connection = new MySqlConnection(ConnStr);
            connection.Open();
            MySqlCommand sqlcmd2;
            sqlcmd2 = connection.CreateCommand();
            sqlcmd2.CommandText = "UPDATE `user` SET Aktive = 0 WHERE Nr = @id;";
            sqlcmd2.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            sqlcmd2.ExecuteNonQuery();
            connection.Close();
            //xxx
        }
    }
