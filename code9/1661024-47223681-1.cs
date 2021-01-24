    using (ExcelRange rng = ws.Cells[i, 1])
    {
        rng.Hyperlink = new Uri("sss.jpg", UriKind.Relative);
        rng.Value = p.Name;
    }
