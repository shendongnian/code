     var itemsControl = new ItemsControl();    
     var factoryPanel = new FrameworkElementFactory(typeof(StackPanel));
     factoryPanel.SetValue(Panel.IsItemsHostProperty, true);
     factoryPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);    
     var template = new ItemsPanelTemplate {VisualTree = factoryPanel};       
     itemsControl.ItemsPanel = template;
