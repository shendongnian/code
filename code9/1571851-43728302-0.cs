    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT 1 select 2 select 3 select 4 select 5 select 6"
                                        , con);
        SqlDataReader reader = cmd.ExecuteReader();
        int x = 50;
        int y = 100;
        do
        {
            DataGridView dgv1 = new DataGridView();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgv1.DataSource = dt;
            dgv1.Left = x;
            dgv1.Top = y;
            dgv1.Height = 60;
            y = y + 70;
            this.Controls.Add(dgv1);
        } while (!reader.IsClosed); -- here is the change
        reader.Close();
    }
