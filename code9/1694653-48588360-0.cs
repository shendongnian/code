    item1.Click += Click;
    item2.Click += Click;
    ....
    void Click(object sender, EventArgs e)
    {
        Control c = sender as Control;     // c = null if sender is not Control
        if (sender == item1)
            Debug.Print(c.Name + ", " + c.Text + ", " + c.Tag);
        else if (sender == item2)
            Debug.Print(c.Name + ", " + c.Text + ", " + c.Tag);
    }
