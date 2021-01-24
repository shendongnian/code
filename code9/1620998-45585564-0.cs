    using (SqlConnection conn = new SqlConnection("server=" + databaseserver + "; database=" + databasename + "; User ID=WPDOMAIN\\spdev; Integrated Security=SSPI;  password=Password123;"))
    {
        conn.Open();
        string password = "Password123";
        string sql = "CREATE LOGIN " + usertobeadded + " WITH PASSWORD = '" +
            password + "';  USE " + databasename + "; CREATE USER " + usertobeadded + " FOR LOGIN " + usertobeadded + ";";
        SqlCommand cmd = new SqlCommand(sql);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}
