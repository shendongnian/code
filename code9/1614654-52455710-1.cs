    public static readonly DependencyProperty MapProperty =
        DependencyProperty.Register("Map", typeof(IList),
        typeof(MyConverter), PropertyMetadata.Create(
        new CreateDefaultValueCallback(() =>
        {
            return new List<object>();
        }
    }));
