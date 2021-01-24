    foreach (ListViewItem li in listView1.Items)
        {
            string condense = "datasource=localhost;port=3306;username=root;password=''";
            string milk = "insert into cashier.sales(Cashier,Orders,Quantity,Size,Price,Date) values ('" + this.cashier.Text + "','" + li.SubItems[0].Text + "','" + li.SubItems[1].Text + "','" + li.SubItems[2].Text + "','" + li.SubItems[3].Text + "','" + this.dateTimePicker1.Value + "');";
            MySqlConnection conDatabase = new MySqlConnection(condense);
            MySqlCommand cmdDatabase = new MySqlCommand(milk, conDatabase);
            MySqlDataReader myReader;
            if (string.IsNullOrEmpty(cashier.Text))
            {
                MessageBox.Show("Please fill the Notes. ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                total.Text = "";
                amount.Text = "";
                change.Text = "";
                while (myReader.Read())
                {
                }
            }
        }
    MessageBox.Show("Orders has been added successfully  ", "Order!", MessageBoxButtons.OK, MessageBoxIcon.Information);
