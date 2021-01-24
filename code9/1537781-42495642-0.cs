     private object oldRootContent;
    
    public ListboxGestureHandlerItem()
    {
        Loaded += ListboxGestureHandlerItem_Loaded;
        LayoutUpdated += ListboxGestureHandlerItem_LayoutUpdated;
    }
    
    private void ListboxGestureHandlerItem_LayoutUpdated(object sender, object e)
    {
        if(oldRootContent != null && (ContentTemplateRoot as Grid) != null)
        {
            (ContentTemplateRoot as Grid).Children.Add(oldRootContent as FrameworkElement);
            oldRootContent = null;
        }
    }
    
    private void ListboxGestureHandlerItem_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        oldRootContent = (sender as ListboxGestureHandlerItem).ContentTemplateRoot;
    
        this.ContentTemplate = Create(typeof(Grid));
    }
    
    protected override void OnPointerMoved(PointerRoutedEventArgs e)
    {
        base.OnPointerMoved(e);
    }
    
    public DataTemplate Create(Type type)
    {
        return XamlReader.Load(@"<DataTemplate 
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""> 
        <" + type.Name + @"/> 
    </DataTemplate>") as DataTemplate;
    }
