    public partial class CULabelConfigControl : UserControl
    {
        public static readonly DependencyProperty CUProperty =
            DependencyProperty.Register(
                nameof(CU),
                typeof(CreditUnion),
                typeof(CULabelConfigControl));
        public CreditUnion CU
        {
            get { return (CreditUnion)GetValue(CUProperty); }
            set { SetValue(CUProperty, value); }
        }
    }
