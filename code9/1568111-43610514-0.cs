    private void cb_college_SelectedIndexChanged(object sender, EventArgs e)
    {
        populateMajors(cb_college.SelectedIndex); // OR More likely Get College ID from Combobox 
    }
    
    private void populateMajors(int CollegeId)
    {
        try
        {
            string SQL;
            SQL = "SELECT DISTINCT major_name FROM majors WHERE <yourcollegeindexcol> = " + CollegeId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQL, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lb_allMajors.Items.Add(reader.GetString(0));
                }
            }
        }
        catch (SqlException err)
        {
            MessageBox.Show(err.Message);
        }
    }
