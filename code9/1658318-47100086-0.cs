    public static readonly DependencyProperty SelectedItemsProperty =
        DependencyProperty.Register(
            nameof(SelectedItems),
            typeof(IEnumerable),
            typeof(MultiSelectionComboBox),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnSelectedItemsChanged));
    public IEnumerable SelectedItems
    {
        get { return (IEnumerable)GetValue(SelectedItemsProperty); }
        set { SetValue(SelectedItemsProperty, value); }
    }
