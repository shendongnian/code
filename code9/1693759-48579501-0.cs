    protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
    {
        base.OnElementChanged(e);
        if (Control!= null)
        {
            //Control.SetBackground(null);
            Control.SetBackgroundResource(Resource.Drawable.et_underline_selector);
        }
    }
