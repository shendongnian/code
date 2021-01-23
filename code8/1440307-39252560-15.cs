    public class ChartBar : ContentControl
    {
        static ChartBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChartBar), 
                new FrameworkPropertyMetadata(typeof(ChartBar)));
        }
        //  Rather than ExpanderContent, we're inheriting ContentControl.Content for the 
        //  main control content. 
        #region SecondaryContent Property
        public Object SecondaryContent
        {
            get { return (Object)GetValue(SecondaryContentProperty); }
            set { SetValue(SecondaryContentProperty, value); }
        }
        public static readonly DependencyProperty SecondaryContentProperty =
            DependencyProperty.Register("SecondaryContent", typeof(Object), typeof(ChartBar),
                new PropertyMetadata(null));
        #endregion SecondaryContent Property
        #region IsExpanded Property
        //  This is optional. I just know I'd end up wanting it. 
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
