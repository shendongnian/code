    public class ChartBar : ContentControl
    {
        static ChartBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChartBar), new FrameworkPropertyMetadata(typeof(ChartBar)));
        }
        //  You don't need an ExpanderContent property; just inherit Content from 
        //  ContentControl. I'm tossing this in to illustrate how to use a DependencyProperty, 
        //  and because if it were me, I know I'd end up wanting to be able to expand these 
        //  things by default in one case or another. 
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
