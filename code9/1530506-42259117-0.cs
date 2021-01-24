    public class NavMenu : Menu
    {
        static NavMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavMenu), new FrameworkPropertyMetadata(typeof(NavMenu)));
        }
        public bool IsExpanded
        {
            get
            {
                return (bool)GetValue(IsExpandedProperty);
            }
            set
            {
                SetValue(IsExpandedProperty, value);
            }
        }
        public static readonly DependencyProperty IsExpandedProperty =
             DependencyProperty.Register("IsExpanded", typeof(bool), typeof(NavMenu), new PropertyMetadata(true));
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            System.Windows.Controls.Primitives.ToggleButton btnMenu = Template.FindName("btnMenu", this) as System.Windows.Controls.Primitives.ToggleButton;
            TimeSpan tsTime = new TimeSpan(0, 0, 0, 0, 500);
            DoubleAnimation mnuAnim = new DoubleAnimation(0.0, MinWidth, tsTime);
            btnMenu.BeginAnimation(WidthProperty, mnuAnim);
        }
    }
    
