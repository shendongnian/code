    public string NullOutAllTagValuesAndSerializeXaml()
    {
      IterateXamlNullOutTag(this.LayoutGrid);
      return System.Xaml.XamlServices.Save(this.LayoutGrid);
    }
    private void IterateXamlNullOutTag(FrameworkElement fe)
    {
      fe.Tag = null;
      var c=VisualTreeHelper.GetChildrenCount(fe);
      for (int i = 0; i < c; i++)
      {
        var fechild=VisualTreeHelper.GetChild(fe, i) as FrameworkElement;
        if (fechild != null)
          IterateXamlNullOutTag(fechild);
      }
    }
