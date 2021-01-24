    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        if(IsImageShowing)
        {
            this.ShowImage();
        }
    }
