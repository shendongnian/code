            string search = textBox2.Text;
            if (hashtable.ContainsKey(search))
            {
                this.Size = new Size(324, 260);
                string value1 = (string)hashtable[search];
                label9.Text= value1.Substring(0, 4);
                label10.Text = value1.Substring(5, 3);
                label11.Text = value1.Substring(9, 6);
                label12.Text = value1.Substring(16, 6);
                label13.Text = value1.Substring(23, 4);
                MessageBox.Show("Found");
            }
            else
            {
                MessageBox.Show("NotFound");
            }
