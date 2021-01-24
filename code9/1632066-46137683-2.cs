    public sealed partial class NavigationMenuButton : UserControl
    {
        public NavigationMenuButton()
        {
            InitializeComponent();
        }
    
        public ICommand NavigateToPageCommand
        {
            get => (ICommand)GetValue(NavigateToPageCommandProperty);
            set => SetValue(NavigateToPageCommandProperty, value);
        }
        public static readonly DependencyProperty NavigateToPageCommandProperty = DependencyProperty.Register(
            "NavigateToPageCommand", typeof(ICommand), typeof(NavigationMenuButton), new PropertyMetadata(null));
    
        public object NavigateToPageCommandParameter
        {
            get => GetValue(NavigateToPageCommandParameterProperty);
            set => SetValue(NavigateToPageCommandParameterProperty, value);
        }
        public static readonly DependencyProperty NavigateToPageCommandParameterProperty = DependencyProperty.Register(
            "NavigateToPageCommandParameter", typeof(object), typeof(NavigationMenuButton), new PropertyMetadata(null));
    
        public string MenuName
        {
            get => (string)GetValue(MenuNameProperty);
            set => SetValue(MenuNameProperty, value);
        }
        public static readonly DependencyProperty MenuNameProperty = DependencyProperty.Register(
            "MenuName", typeof(string), typeof(NavigationMenuButton), new PropertyMetadata(null));
    
        public string SymbolPath
        {
            get => (string)GetValue(SymbolPathProperty);
            set => SetValue(SymbolPathProperty, value);
        }
        public static readonly DependencyProperty SymbolPathProperty = DependencyProperty.Register(
            "SymbolPath", typeof(string), typeof(NavigationMenuButton), new PropertyMetadata(null, (s, e) =>
            {
                // We don't do the x:Bind for this property in XAML because the Image control's Source property
                // doesn't accept a string but a BitmapImage, so one workaround is to do the conversion here.
    
                var self = (NavigationMenuButton)s;
                var image = self.SymbolImage;
                var symbolPath = (string)e.NewValue;
    
               image.Source = new BitmapImage(new Uri(self.BaseUri, symbolPath ?? "/Assets/default_path"));
            }));
    }
