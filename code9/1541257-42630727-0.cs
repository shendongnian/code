    public class FieldText : Control
    {
        static FieldText()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FieldText), new FrameworkPropertyMetadata(typeof(FieldText)));
        }
        public FieldText()
        {
        }
        public static readonly DependencyProperty LabelLengthProperty =
            DependencyProperty.Register("LabelLength", typeof(GridLength),
            typeof(FieldText), new UIPropertyMetadata(new GridLength(25, GridUnitType.Star)));
        public virtual GridLength LabelLength
        {
            get { return (GridLength)GetValue(LabelLengthProperty); }
            set { SetValue(LabelLengthProperty, value); }
        }
        public static readonly DependencyProperty ContentLengthProperty =
            DependencyProperty.Register("ContentLength", typeof(GridLength),
            typeof(FieldText), new UIPropertyMetadata(new GridLength(75, GridUnitType.Star)));
        public virtual GridLength ContentLength
        {
            get { return (GridLength)GetValue(ContentLengthProperty); }
            set { SetValue(ContentLengthProperty, value); }
        }
    }
