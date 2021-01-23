        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.checkBox1State = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
