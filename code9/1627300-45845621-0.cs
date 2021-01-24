    private void textBox14_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBox14.Text))
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from table1", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }
        else
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT id, FirstName, MiddleName, LastName, Gender, DateofBirth, PlaceofBirth, Address, FathersName, FathersOccupation, MothersName, MothersOccupation, Guardian, Relation, GuardianOccupation, image FROM table1 WHERE FirstName LIKE'" + textBox14.Text + "%' OR id LIKE'" + textBox14.Text + "%' OR MiddleName LIKE'" + textBox14.Text + "%' OR LastName LIKE'" + textBox14.Text + "%'", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }
    }
