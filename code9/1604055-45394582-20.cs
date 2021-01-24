    var customerViewModel = new CustomerViewModel
    {
        // Where int needs to be saved as string.
        Id = new GenericeChangeType<int> { Text = "12" },
        Firstname = new ChangeType { Text = "John" },
        Lastname = new ChangeType { },
        Reference = null // May also be omitted.
    }
