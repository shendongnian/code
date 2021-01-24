    private bool CalledFromButton = false;    
    private void Form2_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if(CalledFromButton)
               return;
            DialogResult dialog = MessageBox.Show("Do you really want to quit?", "Exit",
             MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void back_button_Click(object sender, EventArgs e)
        {
            CalledFromButton = true;
            this.Hide();  
        }
