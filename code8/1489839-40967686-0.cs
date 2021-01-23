    ConventionManager.AddElementConvention<RadDataBoundListBox>(DataControlBase.ItemsSourceProperty, "ItemsSource", "SelectionChanged");
    ConventionManager.AddElementConvention<RadDockPanel>(RadDockPanel.DockProperty, "Dock", "DockChanged");
    ConventionManager.AddElementConvention<RadListPicker>(ItemsControl.ItemsSourceProperty, "ItemsSource", "SelectionChanged");
    ConventionManager.AddElementConvention<RadDatePicker>(DateTimePicker.ValueProperty, "Value", "ValueChanged");
    ConventionManager.AddElementConvention<RadTimePicker>(DateTimePicker.ValueProperty, "Value", "ValueChanged");
    ConventionManager.AddElementConvention<RadToggleSwitch>(RadToggleSwitch.IsCheckedProperty, "IsChecked", "CheckChanged");
    ConventionManager.AddElementConvention<RadContextMenuItem>(RadContextMenuItem.CommandProperty, "Command", "Tap");
    ConventionManager.AddElementConvention<RadHubTile>(HubTileBase.CommandProperty, "Command", "Tap");
