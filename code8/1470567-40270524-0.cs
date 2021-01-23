    OrderViewModel model = this.DataContext as OrderViewModel;
    model.OrderStatus = OrderViewModel.OrderStatuses.Updating;
    
    Task.Factory.StartNew(() => /* processing order logic */)
        .ContinueWith(t => model.OrderStatus = OrderViewModel.OrderStatuses.Updated);
