        public static readonly DependencyProperty OwnerProperty = DependencyProperty.Register
        (
            nameof(Owner),
            typeof(Panel),
            typeof(Clock),
            new PropertyMetadata(null, OwnerChanged)
        );
