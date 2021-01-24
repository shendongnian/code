    public static readonly DependencyProperty ComboBoxWidthProperty =
        DependencyProperty.Register(
            "ComboBoxWidth",
            typeof(double),
            typeof(UnitControlBase<TSelectionTypeEnum, TConverterType, TValueType>),
            new PropertyMetadata(175d));
