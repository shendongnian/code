    protected override void OnElementChanged(ElementChangedEventArgs<View> e)
    {
        base.OnElementChanged(e);
        
        //You can refer to @SushiHangover's method for detail's code, here I use the same name.
        Setup();
        Complete = ((ProgressView)Element).Progress;
    }
    
    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);
    
        if (e.PropertyName == "Progress")
        {
            Complete = ((ProgressView)Element).Progress;
        }
    }
