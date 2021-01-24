    var datagrid.AddingNewItem += HandleOnAddingNewItem;
    
    public void HandleOnAddingNewItem(object sender, RoutedEventArgs e)
    {
        if(myConditionIsTrue)
        {
            e.Handled = true; // This will stop the bubbling/tunneling of the event
        }
    }
