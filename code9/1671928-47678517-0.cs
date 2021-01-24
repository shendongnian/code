    public partial class CULabelConfigControl : UserControl
    {
        public static readonly DependencyProperty CurrentReadingProperty =
            DependencyProperty.Register(
                nameof(CurrentReading),
                typeof(CreditUnion),
                typeof(CULabelConfigControl));
        public CreditUnion CurrentReading
        {
            get { return (CreditUnion)GetValue(CurrentReadingProperty); }
            set { SetValue(CurrentReadingProperty, value); }
        }
    }
