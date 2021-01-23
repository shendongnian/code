        SqlConnection con1 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query= "select * from ManCash Where USERNAME='"+txtUser.Text+"'and PASS = '"+txtPass.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con1);
            DataTable DT = new DataTable();
            //  SqlCommand command = new SqlCommand("SELECT Role from ManCash Where USERNAME='" + txtUser.Text + "'and PASS = '" + txtPass.Text + "'", con1);
            // SqlDataReader readr = command.ExecuteReader();
            sda.Fill(DT);
            string a = DT.Rows[0]["Role"].ToString();
            switch (a)
            {
                case "Admin":
                    this.Hide();
                    Manager man = new Manager();
                    man.ShowDialog();
                    this.Close();
                    break;
                case "Staff":
                    this.Hide();
                    Cashier ca = new Cashier();
                    ca.ShowDialog();
                    this.Close();
                    break;
            }
        }
