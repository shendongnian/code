    private void textBox_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
          this.DoDragDrop(sender, DragDropEffects.All);
        }
    }
