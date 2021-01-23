    // Assign an ICollection<CFListCheckbox> to your ViewBag.CF_list 
    ICollection<CFListCheckbox> cfListCB = cfCollection.Select(r => new CFListCheckbox()
    {
        IsChecked = false,
        Text = r.SomeProp,
        Value = r.SomePropOrWhatever
    }).ToList();
 
    // Add logic to re-assign the IsChecked property for your ViewBag.CF_list
    foreach(var entry in model.CF_list_)
    {
        CFListCheckbox item = cfListCB.FirstOrDefault(r => r.Text == entry.SomeProp && r.Value == entry.SomePropOrWhatever);
        if(item != null)
        {
            item.IsChecked = true;
        }
    }
    ViewBag.CF_list = cfListCB;
    return View(model);
