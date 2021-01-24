    private void searchClassSectionSchedule_Load(object sender, EventArgs e)
    {
        comboBox1.DataSource = CSData();
        comboBox1.DisplayMember = "ClassSection";
        comboBox1.ValueMember = "csec_id";
        comboBox1.SelectedIndex = -1;
    }
    //Data of ClassSection is Taken in ComboBox2 from Table "Class_Section" with the help of Stored Procedure (CSEC_View_Data)
    private DataTable CSData()
    {
       DataTable dt = new DataTable();
        string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("CSEC_View_Data", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader r = cmd.ExecuteReader();
                dt.Load(r);
            }
        }
        return dt;
    }
    private void button2_Click(object sender, EventArgs e)
    {
        button1.Enabled = true;
        while (dataGridView1.RowCount > 1)
        {
            dataGridView1.Rows.RemoveAt(0);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            dt = VeiwClassSectionTime();
            dataGridView1.DataSource = dt;
            button1.Enabled = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private DataTable VeiwClassSectionTime()
    {
      DataTable dt = new DataTable();
        string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("CSEC_Time_Display", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("csec_id", comboBox1.SelectedValue);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
        }
        return dt;
    }
}
