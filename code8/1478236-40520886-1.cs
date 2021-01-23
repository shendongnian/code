    // Assign an ICollection<CFListCheckbox> to your ViewBag.CF_list 
    ICollection<CFListCheckbox> cfListCB = cfCollection.Select(r => new CFListCheckbox()
    {
        IsChecked = false,
        Text = r.SomeProp,
        Value = r.SomePropOrWhatever
    }).ToList();
    ViewBag.CF_list = cfListCB;
