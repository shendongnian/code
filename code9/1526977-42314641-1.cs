    public MainPage()
    {
        this.InitializeComponent();
        CoreWindow.GetForCurrentThread().PointerMoved += (s, e) =>
        {
            Point point = e.CurrentPoint.Position;
            IEnumerable<UIElement> elements = VisualTreeHelper.FindElementsInHostCoordinates(point, Border, false);
    
            foreach (var item in elements)
            {
                FrameworkElement feItem = item as FrameworkElement;
                System.Diagnostics.Debug.WriteLine(feItem.Name);
            }
    
            System.Diagnostics.Debug.WriteLine("-----------------------------------------");
        };
    }
