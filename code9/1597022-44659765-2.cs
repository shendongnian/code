    public static void updateClark(string cid, string path)
    {
        var cmdStr = "UPDATE tbl_Path SET folder_path=@path WHERE clark_id=@cid";
        using (var con = ConnectionDB.connection())
        {
            con.Open();
            using (var cmd = new SqlCommand(cmdStr, con))
            {
                cmd.Parameters.AddWithValue(new SqlParameter("@path", path));
                cmd.Parameters.AddWithValue(new SqlParameter("@cid", cid));
                cmd.ExecuteNonQuery();
            }
        }
    }
