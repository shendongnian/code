    public ActionResult delete(int id)
    {
        DeleteClass.Delete(id);
        return RedirectToAction("Index");
    }
    public class DeleteClass
    {
        public static void Delete(int id)
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
