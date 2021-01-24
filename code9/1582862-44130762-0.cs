    public void Addtime(Attendance AddTim) {
        SqlCommand comm = new SqlCommand("select Count(*) from Attendance where UserID=@user", conn);
        comm.Parameters.AddWithValue("@user", AddTim.UserID);
        conn.Open();
        int uc = (int)comm.ExecuteScalar();
        bool sat = (uc > 0);
        conn.Close();
