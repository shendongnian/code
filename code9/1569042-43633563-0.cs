    for (int x = 0; x <= gb.ListDistinctAutoName().Count; x++)
    {
        Button b = new Button();
        b.Content = "button" + x.ToString();
        listOfButtons.Add(b);
        grid.Children.Add(b);
    }
