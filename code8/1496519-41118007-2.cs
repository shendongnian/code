    var stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
    var packIconMaterial = new PackIconMaterial()
    {
        Kind = PackIconMaterialKind.Cookie,
        Margin = new Thickness(4, 4, 2, 4),
        Width = 24,
        Height = 24,
        VerticalAlignment = VerticalAlignment.Center
    };
    stackPanel.Children.Add(packIconMaterial);
    var textBlock = new TextBlock()
    {
        Text = "Test",
        Margin = new Thickness(2, 4, 4, 4),
        VerticalAlignment = VerticalAlignment.Center
    };
    stackPanel.Children.Add(textBlock);
    this.TestButton.Content = stackPanel;
