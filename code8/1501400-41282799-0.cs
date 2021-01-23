    bool check = checkBox1.Checked;
            bool check2 = checkBox2.Checked;
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                MessageBox.Show("ok1 & 1");
            }
            if (checkBox2.Checked == true) {
                MessageBox.Show("ok2");
            }
            if (check == true)
            {
                MessageBox.Show("ok ");
            }
            else
            {
                MessageBox.Show("co nie tak");
            }
