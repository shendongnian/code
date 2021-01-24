    IList.ItempTemplate = new DataTemplate(()=> 
    {
        var textCell = new TextCell();
        textCell.ContextActions.Add(yourAction);
        textCell.SetBinding(TextCell.TextProperty, "."); 
        return textCell; 
    }
    IList.ItemsSource = _routine_names; 
