    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }
        public String Direction
        {
            get { return (String)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }
        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register("Direction",
            typeof(String), typeof(Card), new PropertyMetadata(null));
    }
