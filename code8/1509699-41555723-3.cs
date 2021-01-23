    Property property = await db.Property.FindAsync(id);
    var viewModel = new PropertyDetailViewModel
    {
        Name = property.Name,
        Community = property.Community,
        RegionName = property.Community.Region.Name
    };
    return View(viewModel);
