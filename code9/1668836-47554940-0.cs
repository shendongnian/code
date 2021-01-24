    public int SelectionIndex
    {
        get { return (int)GetValue(SelectionIndexProperty); }
        set { SetValue(SelectionIndexProperty, value); }
    }
    public static readonly DependencyProperty SelectionIndexProperty =
        DependencyProperty.Register(nameof(SelectionIndex), typeof(int), typeof(TabBar),
            new FrameworkPropertyMetadata(-1, SelectionIndex_PropertyChanged));
    protected static void SelectionIndex_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TabBar).OnSelectionIndexChanged(e.OldValue);
    }
    private void OnSelectionIndexChanged(object oldValue)
    {
        switch (SelectionIndex)
        {
            case 0:
                SelectionBox.Margin = new Thickness(0, 10, 0, 0);
                break;
            case 1:
                SelectionBox.Margin = new Thickness(0, 123, 0, 0);
                break;
        }
    }
