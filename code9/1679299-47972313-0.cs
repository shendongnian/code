    panel.OnPaint += Panel_Paint;
    private void Panel_Paint(Object sender, PaintEventArgs e)
    {
        Double scale = ((Panel)sender).Width / 2.0d;
        Double repetitions = Math.Round(scale, 0);
        Double basis = (2.0d * Math.PI) / scale;
        Double petals = 2.0d;
        using (Graphics g = e.Graphics)
        {
            using (Pen pen = new Pen(Brushes.Red, 2.0f))
            {
                for (Double i = 0.0f; i < (repetitions - 1); ++i)
                {
                    Double t0 = i*basis;
                    Double t1 = (i + 1)*basis;
                    Double x0 = Math.Sin(petals * t0) * Math.Cos(t0);
                    Double x1 = Math.Sin(petals * t1) * Math.Cos(t1);
                    Double y0 = Math.Sin(petals * t0) * Math.Sin(t0);
                    Double y1 = Math.Sin(petals * t1) * Math.Sin(t1);
                    g.DrawLine
                        (
                            pen,
                            (Single) ((scale*x0) + scale),
                            (Single) ((scale*y0) + scale),
                            (Single) ((scale*x1) + scale),
                            (Single) ((scale*y1) + scale)
                        );
                }
            }
        }
    }
