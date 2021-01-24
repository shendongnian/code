    void ButtonClickOneEvent(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn != null)
        {
             btn.BackColor = (btn.BackColor == Color.White) ? Color.Red : Color.White;
        }
    }
