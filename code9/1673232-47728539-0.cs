 public event MouseEventHandler txtMouseDoubleClick;
    private void TextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.txtMouseDoubleClick!= null)
                this.txtMouseDoubleClick(this, e);
        }
