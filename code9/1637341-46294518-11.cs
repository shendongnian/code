    private void button1_Click(object sender, EventArgs e)
    {
        AutoScroll = !AutoScroll;
        SetValues();
    }
    
    private void button3_Click(object sender, EventArgs e)
    {
        HScroll = !HScroll;
        SetValues();
    }
    
    private void SetValues()
    {
        button1.Text = $"Auto: {(AutoScroll ? "On" : "Off")}";
        button3.Text = $"HScroll: {(HScroll ? "On" : "Off")}";
        button2.Text = $"Visible: {(HorizontalScroll.Visible ? "On" : "Off")}";
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        HorizontalScroll.Visible = !HorizontalScroll.Visible;
        SetValues();
    }
