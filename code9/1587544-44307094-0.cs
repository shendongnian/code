            ItemsControl ctrol = new ItemsControl();
            FrameworkElementFactory factoryPanel = new FrameworkElementFactory(typeof(StackPanel));
            factoryPanel.SetValue(StackPanel.IsItemsHostProperty, true);
            factoryPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            ItemsPanelTemplate template = new ItemsPanelTemplate();
            template.VisualTree = factoryPanel;
            ctrol.ItemsPanel = new ItemsPanelTemplate()
