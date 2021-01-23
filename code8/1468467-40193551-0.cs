    private void button1_Click(object sender, EventArgs e)
        {
            string username = "admin";
            string password = "admin";
            if ((textBox1.Text == username) && (textBox2.Text == password))
            {
               this.Visible=false;
               Form1 form1 = new Form1();
               form1.show();
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
    
        }
