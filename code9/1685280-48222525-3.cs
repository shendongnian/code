     private void button1_KeyUp(object sender, KeyEventArgs e)
            {
                button1_KeyDown(sender, e);
            }
    
            private void button1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    MessageBox.Show("Enter key has been pressed");
                }
            }
