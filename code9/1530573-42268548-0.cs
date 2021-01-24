    public static View CreateView(Type vType, Type vmType)
    {
        var view = (View)Activator.CreateInstance(vType);
        view.BindingContext = Activator.CreateInstance(vmType);
        return view;    
    }
