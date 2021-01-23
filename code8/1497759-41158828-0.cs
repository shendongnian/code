        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                control.Click += Oncontrol_Click;
            }
        }
        private void Oncontrol_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            MessageBox.Show($"{control.Text} is clicked");
        }
