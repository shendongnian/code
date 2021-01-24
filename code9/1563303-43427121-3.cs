     else if (comboBox1.Text == "Admin.")
            {
                this.Hide();
                string UserEmail = textBox2.Text;
                string UserPassword = textBox1.Text;
                Login objlogin = new Login(UserEmail, UserPassword);
                textBox3.Text = Convert.ToString(objlogin.userid);
                MessageBox.Show(objlogin.Logined());
                //Categorys obj = new Categorys();
                //obj.ShowDialog();
                con.Close();
            }
