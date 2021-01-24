    public MyViewModel()
    {
        elements = new ReactiveList<A>() { ChangeTrackingEnabled = true };
        elements.ItemChanged.Subscribe(args =>
        {
            A a = args.Sender;
            string changedProperty = args.PropertyName;
        });
    }
