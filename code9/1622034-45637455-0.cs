    protected void Chart1_PrePaint(object sender, ChartPaintEventArgs e)
    {
        if (e.ChartElement is ChartArea)
        {
            var ta = new TextAnnotation();
            ta.Text = "81%";
            ta.Width = e.Position.Width;
            ta.Height = e.Position.Height;
            ta.X = e.Position.X;
            ta.Y = e.Position.Y;
            ta.Font = new Font("Ms Sans Serif", 16, FontStyle.Bold);
            Chart1.Annotations.Add(ta);
        }
    }
