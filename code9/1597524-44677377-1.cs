        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (PropertyChecks())
            {
                MessageBox.Show("Some properties are null");
                e.Cancel = true;
            }
        }
