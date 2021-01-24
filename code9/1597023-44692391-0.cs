    public void updateClark(string _cid, string _path)
    {
        string sql = String.Format("UPDATE tbl_Path SET folder_path={0} WHERE clark_id={1}",path,cId);
        SqlCommand cmd = new SqlCommand(sql, ConnectionDB.connection());
        cmd.ExecuteNonQuery();
    }
