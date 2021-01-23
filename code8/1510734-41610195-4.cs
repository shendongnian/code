    private void button_Click(object sender, EventArgs e)
    {
        int w = Math.Abs(P2.Left - P1.Left);
        int h = Math.Abs(P2.Top - P1.Top);
        C2.Left =  (int) (P2.Left + w * 0.5523f);
        C2.Top = P2.Top;
        C1.Left = P1.Left;
        C1.Top = (int) (P1.Top + h * 0.5523f);
        C1.Parent.Invalidate();
    }
