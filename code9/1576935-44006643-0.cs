    MessageBox.Show(comboBox1.Text, "Notification", MessageBoxButtons.OK);
    string command = "select * from " + comboBox1.Text;
    SqlCommand com = new SqlCommand(command, co);
    adp = new SqlDataAdapter(com); //this is declared globally, so I can use it anywhere
    dt = new DataTable();          // same as previous
    adp.Fill(dt);
    dataGridView1.DataSource = dt;
