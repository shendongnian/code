    var items = db.Items.AsQueryable();
    if(SelectedIdCollection != null)
    {
       items = items.Where(cb => SelectedIdCollection.Contains(cb.Id));
    }
    if(date1 != null)
    {
       items = items.Where(cb => cb.Date1 == date1);
    }
