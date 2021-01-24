    // in constructor
    Seat1A.Click += seatSelector;
    Seat1B.Click += seatSelector;
    Seat1C.Click += seatSelector;
    // etc.
    //. . . . . . 
    // !!! - What you need here is 3 states: unavailable, selected, unselected
    // In the beginning you should fill unavailable
    private List<string> _unavailable = new ...   //(fill this on form open from db)
    // paint unavailable in [lets say] blue
    private void PaintUnavailable()
    {
        foreach (Control c in surface.Controls)
        {
            if (c.GetType() == typeof(Button) && _unavailable.Contains(c.Text)) 
            {
                 c.BackColor = Color.Blue; // or ((Button)c).BackColor = Color.Blue
            }
        }
    }
    
    private List<string> _selected = new ...
    private void SeatSelector(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (!_unavailable.Contains(btn.Text))
        {
            if (btn.BackColor == Color.Transparent)
            {
                btn.BackColor = Color.Green;
                _selected.Add(btn.Text);
            }
            else if (BackColor == Color.Green)
            {
                btn.BackColor = Color.Transparent;
                _selected.Remove(btn.Text);
            }
        }
    }
