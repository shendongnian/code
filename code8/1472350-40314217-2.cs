    string LocalizedTitle = "Greeting in user language...";
    CustomerListVM model = new CustomerListModel()
    {
        PageTitle = LocalizedTitle,
        ... // other properties of BaseViewModel
        Customers = db.Customers
    }
    return View(model);
