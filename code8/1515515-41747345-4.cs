    private void drawPanel1_Paint(object sender, PaintEventArgs e)
    {
        foreach (var v in ViewPorts)
        {
            int i = ViewPorts.IndexOf(v);
            e.Graphics.ResetClip();
            e.Graphics.ResetTransform();
            e.Graphics.SetClip(v);
            e.Graphics.TranslateTransform(v.X, v.Y);
            e.Graphics.Clear(colors[i]);
            e.Graphics.DrawString(DateTime.Now.Millisecond + "' - " +i, 
                                  Font, Brushes.Black, 0,0);
        }
    }
