    public sealed partial class NavigationMenuButtonTemplate : UserControl
    {
        public NavigationMenuButtonTemplate()
        {
            this.InitializeComponent();
        }
        public DelegateCommand NavigateToPageCommand
        {
            get { return (DelegateCommand)GetValue(NavigateToPageCommandProperty); }
            set { SetValue(NavigateToPageCommandProperty, value); }
        }
        // Using a DependencyProperty as the backing store for NavigateToPageCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigateToPageCommandProperty =
            DependencyProperty.Register("NavigateToPageCommand", 
                typeof(DelegateCommand), 
                typeof(NavigationMenuButtonTemplate), 
                new PropertyMetadata(0));
        public ButtonInfo ButtonInfo
        {
            get { return (ButtonInfo)GetValue(ButtonInfoProperty); }
            set { SetValue(ButtonInfoProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ButtonInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonInfoProperty =
            DependencyProperty.Register("ButtonInfo", 
                typeof(ButtonInfo), 
                typeof(NavigationMenuButtonTemplate), 
                new PropertyMetadata(0));        
    }
