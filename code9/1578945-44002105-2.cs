        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => Work(5000));
            textBox1.Text = @"DONE";
        }
        private void Work(int millisecodns)
        {
            Thread.Sleep(millisecodns);
        }
