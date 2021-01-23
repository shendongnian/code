    public DataTemplate GenerateTemplate() {
      var template = new DataTemplate();
      var p = new FrameworkElementFactory(typeof(Grid));
      p.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
      p.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
      ...
      template.VisualTree = p;
      return template;
    }
