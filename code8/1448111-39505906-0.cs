    if(this.ItemsSource == null)
    {
        this.ItemsSource = (new List<object>()).AsEnumerable();
    }
    (tb.ItemsSource as IList).Add(item);
