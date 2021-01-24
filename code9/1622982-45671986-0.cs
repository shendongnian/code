    public void handleChecked(object sender, RoutedEventArgs e)
    {
        CheckBox chk = sender as CheckBox;
        NewsSrcTableItm itm = chk.DataContext as NewsSrcTableItm;
        //get index:
        var sourceCollection = newsStories.ItemsSource as IList<NewsSrcTableItm>;
        int index = sourceCollection.IndexOf(itm);
        //...
    }
