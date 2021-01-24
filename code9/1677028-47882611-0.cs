    public void ButtonClickHandler(Object sender,EventArgs e)
    {
        if (((Button)sender).BackColor == Color.LightGreen)
        {
            ((Button)sender).BackColor = // Your default color
        }
        else
        {
            ((Button)sender).BackColor = Color.LightGreen;
        }
    }
