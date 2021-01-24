    Task.Factory.StartNew(()=> DataHelper.GetVendors())
        .ContinueWith(task => 
        {
            Vendors.Clear();
            foreach (var vendor in task.Result)
                Vendors.Add(vendor);
            RaisePropertyChanged(nameof(Vendors));
            Vendor = Vendors.FirstOrDefault();
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
