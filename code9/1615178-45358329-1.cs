    _printerlist.ForEach(p => lstViewPrinters.Items.Add(
        new ListViewItem(new[]
        {
            p.Hostname,
            p.Manufacturer,
            p.Model
        })));
