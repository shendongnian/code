    public static DependencyProperty IsDirtyProperty = DependencyProperty.Register(
        "IsDirty",
        typeof(bool),
        typeof(MyTextField),
        new PropertyMetadata(false));
