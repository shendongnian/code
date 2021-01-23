    public void Delete(int ID)
    {
        SqlCommand cmd = new SqlCommand("delete from tblContact where ID = " + ID + "'", cn);
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    }
