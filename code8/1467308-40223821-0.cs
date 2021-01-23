    var psinstance = System.Management.Automation.PowerShell.Create();
    psinstance.AddScript("ping 127.0.0.1");
    var output = new System.Collections.ObjectModel.ObservableCollection<string>();
    output.CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
    {
        foreach(var item in e.NewItems)
            Console.WriteLine(item);
    };
    psinstance.Invoke(null, output);
