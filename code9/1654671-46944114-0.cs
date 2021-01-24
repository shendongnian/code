    // Image
    var imageFactory = new FrameworkElementFactory(typeof(Image));
    imageFactory.SetValue(WidthProperty, 15);
    imageFactory.SetValue(HeightProperty, 15);
    imageFactory.SetBinding(Image.SourceProperty, new Binding("Icon"));
    imageFactory.SetValue(DockPanel.DockProperty, Dock.Left);
    // Label
    var labelFactory = new FrameworkElementFactory(typeof(Label));
    labelFactory.SetBinding(ContentProperty, new Binding("Column1_Content"));
    labelFactory.SetValue(WidthProperty, 180);
    labelFactory.SetValue(FontSizeProperty, 12);
    labelFactory.SetValue(HorizontalContentAlignmentProperty, HorizontalAlignment.Left);
    labelFactory.SetValue(DockPanel.DockProperty, Dock.Left);
    // DockPanel
    var dockPanelFactory = new FrameworkElementFactory(typeof(DockPanel));
    dockPanelFactory.AppendChild(imageFactory);
    dockPanelFactory.AppendChild(labelFactory);
    GridViewColumn Column_1 = new GridViewColumn()
    {
        Header = "Column_1",
        Width = 200
    };
    DataTemplate template = new DataTemplate
    {
        VisualTree = dockPanelFactory
    };
    Column_1.CellTemplate = template;
