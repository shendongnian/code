    public class FilterDataGridTextColumn : DataGridTextColumn
    {
        public static readonly DependencyProperty FilterNameProperty =
            DependencyProperty.Register("FilterName", typeof(string), typeof(FilterDataGridTextColumn));
        public string FilterName
        {
            get { return (string) GetValue(FilterNameProperty); }
            set { SetValue(FilterNameProperty, value); }
        }
    }
