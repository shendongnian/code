    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        if (container is ListViewItem cont)
        {
            if (cont.Tag != null && long.TryParse(cont.Tag.ToString(), out var token))
            {
                cont.UnregisterPropertyChangedCallback(ListViewItem.IsSelectedProperty, token);
            }
    
            cont.Tag = cont.RegisterPropertyChangedCallback(ListViewItem.IsSelectedProperty, (s, e) =>
            {
                cont.ContentTemplateSelector = null;
                cont.ContentTemplateSelector = this;
            });
    
            if (cont.IsSelected)
            {
                return SelectedItemTemplate;
            }
    
            return DefaultTemplate;
        }
    
        return DefaultTemplate;
    }
