    RectangleF InnerPlotPositionClientRectangle(Chart chart, ChartArea CA)
    {
        RectangleF IPP = CA.InnerPlotPosition.ToRectangleF();
        RectangleF CArp = ChartAreaClientRectangle(chart, CA);
        float pw = CArp.Width / 100f;
        float ph = CArp.Height / 100f;
        return new RectangleF(CArp.X + pw * IPP.X, CArp.Y + ph * IPP.Y,
                                pw * IPP.Width, ph * IPP.Height);
    }
