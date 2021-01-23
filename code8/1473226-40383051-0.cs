    public static readonly DependencyProperty StrategiesProperty = DependencyProperty.Register(
            "Strategies",
            typeof(IEnumerable<FilterType>),
            typeof(FilterPicker),
            new FrameworkPropertyMetadata
            {
                DefaultValue = ImmutableList<FilterType>.Empty, //Custom implementation of IEnumerable
                PropertyChangedCallback = StrategiesChangedCallback,
                BindsTwoWayByDefault = false,
            });
