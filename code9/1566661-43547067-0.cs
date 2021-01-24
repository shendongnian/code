        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Visible = true;
            await Task.Delay(TimeSpan.FromSeconds(1)); // whatever time delay you need in here
            label1.Visible = false;
            button1.Enabled = true;
        }
