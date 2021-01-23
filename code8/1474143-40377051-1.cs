    public static readonly DependencyProperty ColumnsCountProperty =
        DependencyProperty.Register(
            "ColumnsCount", typeof(int), typeof(CabinetGrid),
             new PropertyMetadata(OnColumnsCountPropertyChanged));
    private static void OnColumnsCountPropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
         var cabinetGrid = (CabinetGrid)obj;
         // do something with the CabinetGrid instance
    }
