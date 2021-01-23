    private void ClearBut_Click(object sender, EventArgs e)
    {
        string comand = "TRUNCATE TABLE TestTable"
        SqlCommand cmd = new SqlCommand(comand, conn); // here conn is connection
        cmd.ExecuteNonQuery();
    
    }
