    public void iniciarsessaobutton_Click(object sender, EventArgs e)
    {
        string txtuser = textusername.Text;
        string txtpass = textlogin.Text;
        // Put your connection into a using() block
        using (MySqlConnection conn = new MySqlConnection(variableWithYourConnectionStringHere))
        {
            // Put your commend into a using() block
            // enclose your column names in backticks to avoid conflict with MySql reserved keywords
            // add a placeholder (@username) for your parameter
            // use LIMIT 1 if you only expect 1 row matching your condition
            using(MySqlCommand cmd = new MySqlCommand("SELECT `password` FROM empregados WHERE `user` = @username LIMIT 1", conn))
            {
                mConn.Open();
                // add a parameter with your TextBox value
                cmd.Parameters.AddWithValue("@username", txtuser);
                // If you only retrieve 1 value, use ExecuteScalar to return only 1 value
                // cast the returned object as string
                string getpass = cmd.ExecuteScalar() as string;
                if (getpass == txtpass)
                {
                    MessageBox.Show("Sessão iniciada");
                    Admin adm = new Admin();
                    this.Hide();
                    adm.Show();
                }
                else
                {
                    MessageBox.Show("Não foi possivel iniciar sessão. Insira a password corretamente.");
                }
            }
        }
    }
