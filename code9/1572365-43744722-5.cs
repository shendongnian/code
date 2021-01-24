        // List that will hold date values
        List<DateTime> _times = new List<DateTime>();
        public Form1()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.textBox_Task.Text != "")
            {
                listView1.View = View.Details;
                ListViewItem lvwItem = listView1.Items.Add(dateTimePicker1.Text);
                var day = dateTimePicker1.Value.Day;
                var month = dateTimePicker1.Value.Month;
                var year = dateTimePicker1.Value.Year;
                // Add Datetime to list
                DateTime dateTime = new DateTime(year, month, day);
                _times.Add(dateTime);
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
        void t_Tick(object sender, EventArgs e)
        {
            // loop thru all datetimes and calculate the difference
            foreach (var dateTime in _times)
            {
                TimeSpan ts = dateTime.Subtract(DateTime.Now);
                var hari = dateTimePicker1.Value.Day;
                Console.WriteLine(ts.Days);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (ts.Days == 0)
                    {
                        listView1.Items[i].SubItems[3].Text = "DEADLINE";
                    }
                    else
                    {
                        listView1.Items[i].SubItems[3].Text = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds to go'");
                    }
                }
            }
        }
    }
