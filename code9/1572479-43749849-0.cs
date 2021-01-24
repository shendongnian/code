    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }
        public DataTemplate CardDirectionTemplate
        {
            get { return (DataTemplate)GetValue(CardDirectionTemplateProperty); }
            set { SetValue(CardDirectionTemplateProperty, value); }
        }
        public static readonly DependencyProperty CardDirectionTemplateProperty = DependencyProperty.Register("CardDirectionTemplate", 
            typeof(DataTemplate), typeof(Card), new PropertyMetadata(null));
    }
