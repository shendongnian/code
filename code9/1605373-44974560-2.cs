    public int Index
    {
        get { return (int)GetValue(IndexProperty); }
        set { SetValue(IndexProperty, value); }
    }
    public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(ListViewIndexSelectorControl), new PropertyMetadata(0));
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if(int.TryParse(theTextBox.Text, out int result))
        {
            Index = result;
        }
    }
