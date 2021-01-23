    private readonly List<View> subViews = new List<View>();
    public void AddSubViews(params View[] views) // you can use params here
    {
       subViews.AddRange(views);
    }
