    protected override void OnParentSet()
    {
        base.OnParentSet();
        
        if (Parent == null)
        {
            //Clear a bunch of bindings or dispose of ViewModel objects 
            BindingContext =
                _listView.ItemsSource = null;
        }
    }
