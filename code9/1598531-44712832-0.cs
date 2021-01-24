    private void ListBox1_MouseMove(object sender, MouseEventArgs e)
    {
    
        int newindex = ListBox1.IndexFromPoint(e.Location);
        if (newindex != index) //avoid flickering
        {
            int i;
            this.SuspendLayout();
            for (i = 0; i < (this.listBox1.Items.Count); i++)
            {
                if (this.listBox1.GetItemRectangle(i).Contains(this.listBox1.PointToClient(MousePosition)))
                {
    
                    this.listBox1.SelectedIndex = i;
                    index = newindex;
                    //return; why return?
                }
            }
            this.ResumeLayout(true);
        }
    }
