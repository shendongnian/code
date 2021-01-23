    public static readonly DependencyProperty BehaviorCollectionProperty =
        DependencyProperty.Register(
            $"{nameof(CompositeBehavior<T>)}<{typeof(T).Name}>",
            typeof(BehaviorCollection),
            typeof(CompositeBehavior<T>),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.NotDataBindable));
    public BehaviorCollection BehaviorCollection
    {
        get
        {
            var collection = GetValue(BehaviorCollectionProperty) as BehaviorCollection;
            if (collection == null)
            {
                var constructor = typeof(BehaviorCollection)
                    .GetConstructor(
                        BindingFlags.NonPublic | BindingFlags.Instance,
                        null, Type.EmptyTypes, null);
                collection = (BehaviorCollection) constructor.Invoke(null);
                collection.Changed += OnCollectionChanged;
                SetValue(BehaviorCollectionProperty, collection);
            }
            return collection;
        }
    }
