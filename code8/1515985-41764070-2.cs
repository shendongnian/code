    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
         if (e.Button == MouseButtons.Right
              && this.GetChildAtPoint(e.Location)?.Name == "enableButton")
         {
            ContextMenu.Show();
         }
     }
