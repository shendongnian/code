    SqlConnection conn = new SqlConnection(*"Your Connection Settings"*);
    string command="Select Note FROM Notes Where NoteName='" + comboNoteName.Text + "'";
    SqlDataAdapter da = new SqlDataAdapter(command, conn);
    DataTable dt = new DataTable();
    da.Fill(dt);
