    private ICommand _renameCommand;
    /// <summary>
    /// Command used to change the name of the selected profile.
    /// </summary>
    public ICommand RenameCommand
    {
        get
        {
            return _renameCommand ?? (_renameCommand = new RelayCommand<object>(obj =>
            {
                    
                if(!(obj is object[] values)) return;
                    
                    
                if(!(values[0] is TextBox || values[0] is SetConfiguration) || !(values[1] is bool value)) return;
                if (values[0] is TextBox txtBox)
                {
                    txtBox.IsReadOnly = value;
                    if (!value)
                    {
                        txtBox.Focus();
                        txtBox.SelectAll();
                    }
                }
                if (values[0] is SetConfiguration config)
                {
                    var listView = ListProfileView.ItemContainerGenerator.ContainerFromItem(config) as ListViewItem;
                    var presenter = FindVisualChild<ContentPresenter>(listView);
                    if(!(presenter.ContentTemplate.FindName("ProfileName", presenter) is TextBox txtBoxItem)) return;
                    if (!value)
                    {
                        txtBoxItem.Focus();
                        txtBoxItem.SelectAll();
                    }
                    txtBoxItem.IsReadOnly = value;
                }
            }));
        }
    }
    private static TChildItem FindVisualChild<TChildItem>(DependencyObject obj)
        where TChildItem : DependencyObject
    {
        for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            var child = VisualTreeHelper.GetChild(obj, i);
            if (child is TChildItem item)
                return item;
                
            var childOfChild = FindVisualChild<TChildItem>(child);
            if (childOfChild != null)
                return childOfChild;
        }
        return null;
    }
