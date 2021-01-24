    protected void newBtn_Click(object sender, EventArgs e)
            {
            String cs = "Database=trafikkskole; User=root; Password=root";
            MySqlConnection dbconnect = new MySqlConnection(cs);
            try
            {
                if (!string.IsNullOrWhiteSpace(inputUser.Text) && !string.IsNullOrWhiteSpace(inputPw.Text))
                {
                    dbconnect.Open();
                    Label1.Text = "Gratulerer! Du har nå laget en bruker!";
                    string qry = "INSERT INTO user(username, password) VALUES (@un, @pw)";
                    cmd = new MySqlCommand(qry, dbconnect);
                    cmd.Parameters.AddWithValue("@un", inputUser.Text);
                    cmd.Parameters.AddWithValue("@pw", inputPw.Text);
                    cmd.Connection = dbconnect;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Label1.Text = "ERROR";
                }
            }
            catch (Exception)
            {
                Label1.Text = "Brukernavnet er allerede i bruk";
            }
            finally
            {
                dbconnect.Close();
            }
        }
