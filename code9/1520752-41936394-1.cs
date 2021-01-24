    private void SetSelectedItems()
    {
        SelectedItems.Clear();
            
        foreach (Node node in _nodeList)
        {
            if (node.IsSelected && node.Title != "All")
            {
                if (this.ItemsSource.Count > 0)
                    SelectedItems.Add(this.ItemsSource.Cast<object>().ToList().First(x => x.ToString() == node.Title));
            }
        }
    }
