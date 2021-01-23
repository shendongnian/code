    public class ChartBar : ContentControl
    {
        static ChartBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChartBar), new FrameworkPropertyMetadata(typeof(ChartBar)));
        }
        #region IsExpanded Property
        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(ChartBar),
                new PropertyMetadata(false));
        #endregion IsExpanded Property
    }
