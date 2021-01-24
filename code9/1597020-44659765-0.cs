    public static void updateClark(string cid, string path)
    {
        var cmdStr = "UPDATE tbl_Path SET folder_path='@path' WHERE clark_id='@cid'";
        using (var con = new SqlConnection(ConnectionDB.connection().ConnectionString))
        {
            con.Open();
            using (var cmd = new SqlCommand(cmdStr, ConnectionDB.connection()))
            {
                cmd.Parameters.Add(new SqlParameter("@path", path));
                cmd.Parameters.Add(new SqlParameter("@cid", cid));
                cmd.ExecuteNonQuery();
            }
        }
    }
