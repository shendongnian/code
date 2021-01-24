    private void CenterOwner()
    {
        if (Owner != null)
        {
            double top = Owner.Top + ((Owner.Height - this.ActualHeight) / 2);
            double left = Owner.Left + ((Owner.Width - this.ActualWidth) / 2);
    
            this.Top = top < 0 ? 0 : top;
            this.Left = left < 0 ? 0 : left;
        }
    }
 
