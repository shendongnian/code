     else if (comboBox1.Text == "Admin.")
            {
                this.Hide();
                string UserEmail = textBox2.Text;
                string UserPassword = textBox1.Text;
                Login objlogin = new Login(UserEmail, 
                MessageBox.Show(objlogin.Logined());
                textBox3.Text = Convert.ToString(objlogin.userid);
                Categorys obj = new Categorys(objlogin.userid);
                obj.ShowDialog();
                con.Close();
            }
