    public static DependencyProperty IsDirtyProperty = DependencyProperty.Register(
        nameof(IsDirty),
        typeof(bool),
        typeof(MyTextField),
        new PropertyMetadata(false));
