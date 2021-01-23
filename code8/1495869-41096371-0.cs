        using (SqlConnection conn = new SqlConnection("Data Source=PC; Initial Catalog=DATABASE; Integrated Security=True"))
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("select * from branch order by office asc", conn);
            SqlDataReader reader = sc.ExecuteReader();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("OFFICE", typeof(string));
            dt.Load(reader);
            comboboxDestination.ValueMember = "ID";
            comboboxDestination.DisplayMember = "OFFICE";
            comboboxDestination.DataSource = dt;
            conn.Close();
        }
