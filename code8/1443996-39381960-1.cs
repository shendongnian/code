    public List<NavMenuItem> NavList { get; } = new List<NavMenuItem>(new[]
    {
        new NavMenuItem()
        {
            Symbol = Symbol.Add,
            Label = "Add feed",
            DestPage = typeof(AddFeedView),
            Arguments = typeof(RootPages)
        },
        new NavMenuItem()
        {
            Symbol = Symbol.Edit,
            Label = "Edit feeds",
            DestPage = typeof(EditFeedView),
            Arguments = typeof(RootPages)
        }
    });
