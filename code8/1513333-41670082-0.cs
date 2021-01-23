    protected override void InitializeViewLookup()
    {
        var viewsLookup = new Dictionary<Type, Type>
        {
            [typeof(MovementViewModel)] = typeof(MovementPage)
        };
    
        var container = Mvx.Resolve<IMvxViewsContainer>();
        container.AddAll(viewsLookup);
    }
