    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        if (!_button2Pressed)
            return;
        using (var gfx = e.Graphics)
        using (var brush = new SolidBrush(Color.FromArgb(255, 255, 0)))
            gfx.FillRectangle(brush, 0, 0, 600, 800);
        _button2Pressed = false;
    }
    private void button2_Click(object sender, EventArgs e)
    {
        _button2Pressed = true;
        Invalidate();
    }
    private bool _button2Pressed;
