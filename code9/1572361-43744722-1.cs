     private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.textBox_Task.Text != "")
            {
                listView1.View = View.Details;
                ListViewItem lvwItem = listView1.Items.Add(dateTimePicker1.Text);
                var day = dateTimePicker1.Value.Day;
                var month = dateTimePicker1.Value.Month;
                var year = dateTimePicker1.Value.Year;
                DateTime dateTime = new DateTime(year, month, day);
                _times.Add(dateTime);
                Timer t = new Timer();
                t.Interval = 500;
                t.Tick += new EventHandler(t_Tick);
                t.Start();
                lvwItem.SubItems.Add(textBox_Task.Text);
                lvwItem.SubItems.Add(textBox_Note.Text);
                lvwItem.SubItems.Add("");
                this.dateTimePicker1.Focus();
                this.textBox_Note.Focus();
                this.textBox_Task.Focus();
                this.textBox_Task.Clear();
                this.textBox_Note.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a task to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox_Task.Clear();
                this.textBox_Note.Clear();
            }
        }
