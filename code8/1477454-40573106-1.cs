    chart1.ApplyPaletteColors();
    chart1.Legends[0].Enabled = false;
    Legend L2 = new Legend();
    chart1.Legends.Add(L2);
    L2.Docking = Docking.Right;
    foreach (DataPoint dp in yourSeries.Points)
    {
        LegendItem LI = new LegendItem(dp.YValues[0].ToString("0.##"), dp.Color, "");
        LI.BorderWidth = 0;
        L2.CustomItems.Add(LI);
    }
