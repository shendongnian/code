    public static readonly DependencyProperty ItemsSourceProperty =
             DependencyProperty.Register("ItemsSource", typeof(IList), typeof(MultiSelectComboBox), new FrameworkPropertyMetadata(null,
        new PropertyChangedCallback(MultiSelectComboBox.OnItemsSourceChanged)));
    public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IList), typeof(MultiSelectComboBox), new FrameworkPropertyMetadata(null,
        new PropertyChangedCallback(MultiSelectComboBox.OnSelectedItemsChanged)));
    public IList ItemsSource
    {
        get { return (IList)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    public IList SelectedItems
    {
        get { return (IList)GetValue(SelectedItemsProperty); }
        set { SetValue(SelectedItemsProperty, value); }
    }
