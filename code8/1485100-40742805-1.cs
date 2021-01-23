    private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                
                int number = rdm.Next(0, 101);
                label1.Text = number.ToString();
            }
        }
