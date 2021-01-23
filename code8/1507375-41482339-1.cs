    cbo.DisplayMember = "OrderDate";
    cbo.ValueMember = "Order";
    cbo.DataSource = customer.Orders.Where(x => x.Month == month)
        .Select(o => new { o.OrderDate, Order = o })
        .ToList();
    
    cbo.DataBindings.Add(new Binding("SelectedValue", bindingSource, "Order", true, DataSourceUpdateMode.OnPropertyChanged, null));
