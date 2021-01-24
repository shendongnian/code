    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {          
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Do you want to exit?",
                               "Closing application",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
