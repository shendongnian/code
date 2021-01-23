    public BlankPage()
    {
        this.InitializeComponent();
        this.Loaded += Page_Loaded;
        this.SizeChanged += Page_SizeChanged;
    }
    
    private ItemsControl itemscontrol;
    private double width;
    private double itemwidth;
    private bool commandschanged;
    
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        itemscontrol = FindChildOfType<ItemsControl>(myappbar);
        var appbarbutton = myappbar.PrimaryCommands.FirstOrDefault() as AppBarButton;
        itemwidth = appbarbutton.ActualWidth;
        width = itemscontrol.ActualWidth;
    }
    
    private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        var commands = myappbar.SecondaryCommands;
        if (commands.Count != 0)
            foreach (var command in commands.Reverse())
            {
                var appbarbutton = command as AppBarButton;
                myappbar.SecondaryCommands.Remove(appbarbutton);
                myappbar.PrimaryCommands.Add(appbarbutton);
                appbarbutton.IsEnabled = true;
            }
        commandschanged = false;
    }
    
    private void myappbar_Opening(object sender, object e)
    {
        var windowwidth = Window.Current.Bounds.Width;
        if (width > windowwidth && !commandschanged)
        {
            var secondarycommandsCount = Math.Ceiling((width - windowwidth) / itemwidth);
            for (int i = 0; i < secondarycommandsCount; i++)
            {
                var command = myappbar.PrimaryCommands.Last() as AppBarButton;
                Debug.WriteLine(command.IsEnabled);
                myappbar.PrimaryCommands.Remove(command);
                myappbar.SecondaryCommands.Add(command);
            }
            commandschanged = true;
        }
    }
    
    public static T FindChildOfType<T>(DependencyObject root) where T : class
    {
        var queue = new Queue<DependencyObject>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            DependencyObject current = queue.Dequeue();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
            {
                var child = VisualTreeHelper.GetChild(current, i);
                var typedChild = child as T;
                if (typedChild != null)
                {
                    return typedChild;
                }
                queue.Enqueue(child);
            }
        }
        return null;
    }
