    public partial class AlternatingListView
    {
        public static readonly DependencyProperty OddRowBackgroundProperty = DependencyProperty.Register(
            nameof(OddRowBackground),
            typeof(Brush),
            typeof(AlternatingListView),
            new PropertyMetadata(null));
    
        public static readonly DependencyProperty EvenRowBackgroundProperty = DependencyProperty.Register(
            nameof(EvenRowBackground),
            typeof(Brush),
            typeof(AlternatingListView),
            new PropertyMetadata(null));
    
        public Brush OddRowBackground
        {
            get { return (Brush)GetValue(OddRowBackgroundProperty); }
            set { SetValue(OddRowBackgroundProperty, (Brush)value); }
        }
    
        public Brush EvenRowBackground
        {
            get { return (Brush)GetValue(EvenRowBackgroundProperty); }
            set { SetValue(EvenRowBackgroundProperty, (Brush)value); }
        }
    }
