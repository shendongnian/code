    public void DeleteEmpById(int Key)
    {
        using (SqlConnection conn = db.CreateConnection())
        using (SqlCommand cmd = new SqlCommand("sp_DeleteById", conn)) {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", Key);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
