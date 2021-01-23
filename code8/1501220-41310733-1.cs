    categories = getCategories();
    foreach (var category in categories)
    {
       var viewCell = new ViewCell 
       { 
          View = new StackLayout()
          {
             Padding = new Thickness(20, 0, 20, 0),
             HorizontalOptions = LayoutOptions.FillAndExpand,
             Children = { 
                new StackLayout() {
                   Orientation = StackOrientation.Horizontal,
                   VerticalOptions = LayoutOptions.CenterAndExpand,
                   Children = {
                      new StackLayout() {
                         HorizontalOptions = LayoutOptions.StartAndExpand,
                         Children = {
                            new Label { Text = category.Name}
                          },
                      new StackLayout() {
                         HorizontalOptions = LayoutOptions.EndAndExpand,
                         Orientation = StackOrientation.Horizontal,
                         Children = {
                            new Label { Text = category.Count},
                            new Image { Source = "right1.png",
                                        IsVisible = category.Selected }
                         }
                      }
                   }
                }
             }
           }
        };
        viewCell.Tapped += (sender, e) =>
        {
           if (category.Selected == false)
           {
              App.DB.UpdateSelected(true);
           }
           else
           {
              App.DB.UpdateSelected(false);
           }
           categories = getCategories();
           totalPhraseCount = getTotalPhraseCount();
           Title = totalPhraseCount.ToString() + " phrases";
         };
       
    }
    tableSection.Add(viewCell);
    tableSection.ForceLayout();
    // Or try tableview.Forcelayout();
    // Or try parent_stacklayout.ForceLayout();
