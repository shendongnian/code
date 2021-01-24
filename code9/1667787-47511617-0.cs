    public partial class DynamicTabControl : UserControl, INotifyPropertyChanged
    {
        public DynamicTabControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<ITabItem>), typeof(DynamicTabControl));
        public IEnumerable<ITabItem> ItemsSource
        {
            get { return (IEnumerable<ITabItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty TabContentTemplateProperty =
            DependencyProperty.Register("TabContentTemplate", typeof(DataTemplate), typeof(DynamicTabControl));
        public DataTemplate TabContentTemplate
        {
            get { return (DataTemplate)GetValue(TabContentTemplateProperty); }
            set { SetValue(TabContentTemplateProperty, value); }
        }
    }
