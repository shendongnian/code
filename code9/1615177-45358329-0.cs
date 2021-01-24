    var _printerlist = new List<Printer>();
    for (int i = 0; i < _printerlist.Count; i++)
    {
        lstViewPrinters.Items.Add(
            new ListViewItem(new[]
            {
                _printerlist[i].Hostname,
                _printerlist[i].Manufacturer,
                _printerlist[i].Model
            }));
    }
