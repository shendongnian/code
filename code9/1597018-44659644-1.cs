    public void updateClark(string _cid, string _path)
    {
        using (SqlCommand cmd = new SqlCommand(@"UPDATE tbl_Path SET folder_path=@folderPath WHERE clark_id=@clarkId", ConnectionDB.connection()))
        {
           cmd.Parameters.AddWithValue("folderPath", _path);
           cmd.Parameters.AddWithValue("clarkId", _cid);
           cmd.ExecuteNonQuery();
        }
    }
