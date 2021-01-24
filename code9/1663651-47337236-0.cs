    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(UserControl1),
                new PropertyMetadata(null));
        public ColumnSet ColumnSet
        {
            get { return (ColumnSet)GetValue(ColumnSetProperty); }
            set { SetValue(ColumnSetProperty, value); }
        }
        public static readonly DependencyProperty ColumnSetProperty =
            DependencyProperty.Register(nameof(ColumnSet), typeof(ColumnSet), typeof(UserControl1),
                new PropertyMetadata(ColumnSet.None));
    }
    public enum ColumnSet
    {
        None,
        NameFood,
        NameNumberState,
        FredBarneyWilma
    }
