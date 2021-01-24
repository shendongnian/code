    string query = "SELECT * FROM Child WHERE " + Properties.Settings.Default.ComboBox + " LIKE '@Textbox'";
    string cnStr = "Data Source=LT-SDGFLD-1803;Initial Catalog=Test;Persist Security Info=True;User ID=sa;Password=";
    DataTable dt = new DataTable();
    using (SqlDataAdapter da = new SqlDataAdapter(query, cnStr)) {
        da.SelectCommand.Parameters.Add("@Textbox", System.Data.SqlDbType.VarChar).Value = Properties.Settings.Default.TextBox;
        da.Fill(dt);
    }
    dataGridView3.DataSource = dt;
