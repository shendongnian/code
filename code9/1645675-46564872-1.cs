    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (SizeHasChanged(width, height)) // elided, just compare width, height with the stored values
        {
            StoreSize(width, height); // store in private members
            if (IsLandscape)
            {
                this.OuterStackLayout.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                this.OuterStackLayout.Orientation = StackOrientation.Vertical;
            }
        }
    }
    public bool IsLandscape => _width > _height;
