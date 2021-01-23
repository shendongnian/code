    void AddLegendItem(Legend L, Series s, Color mc)
    {
        LegendItem lit = new LegendItem();
        lit.BorderColor = mc;
        lit.Color = mc;
        lit.SeriesName = s.Name;
        lit.Name = s.Name;
        L.CustomItems.Add(lit);
     }
