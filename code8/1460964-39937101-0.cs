    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
         if(e.KeyCode == Keys.F)
         {
              e.Handled = true;
              MessageBox.Show("F"); 
         }
         else if(e.KeyCode  == Keys.G)
         {
              e.Handled = true;
              MessageBox.Show("G");
         }
    }
