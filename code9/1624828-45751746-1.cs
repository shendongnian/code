    private void DrawMargins(object sender, PaintEventArgs e)
    {
        Control parent = sender as Control;
        foreach ( Control ctl in parent.Controls)
        { 
            SolidBrush brush = ctl.Tag as SolidBrush;
            if (brush == null) continue;
            e.Graphics.FillRectangle(brush, ctl.Left - ctl.Margin.Left,
                ctl.Top - ctl.Margin.Top,
                ctl.Width + ctl.Margin.Horizontal,
                ctl.Height + ctl.Margin.Vertical);
        }
    }
