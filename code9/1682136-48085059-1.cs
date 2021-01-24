    private void popup_MouseMove(object sender, MouseEventArgs e)
    {
        if (!this.Tedavi_Popup.IsOpen)
            this.Tedavi_Popup.IsOpen = true;
        var mousePosition = e.GetPosition(this.myWindow);
        this.Tedavi_Popup.HorizontalOffset = mousePosition.X;
        this.Tedavi_Popup.VerticalOffset = mousePosition.Y;
         
    }
