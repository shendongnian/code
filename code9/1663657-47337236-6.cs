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
        public ViewPurpose ViewPurpose
        {
            get { return (ViewPurpose)GetValue(ViewPurposeProperty); }
            set { SetValue(ViewPurposeProperty, value); }
        }
        public static readonly DependencyProperty ViewPurposeProperty =
            DependencyProperty.Register(nameof(ViewPurpose), typeof(ViewPurpose), typeof(UserControl1),
                new PropertyMetadata(ViewPurpose.None));
    }
    public enum ViewPurpose
    {
        None,
        FoodPreference,
        ContactInfo,
        FredBarneyWilma
    }
