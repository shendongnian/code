    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        Character c = e.NewValue as Character;
        if (c != null)
        {
            //a character was selected...
        }
    }
