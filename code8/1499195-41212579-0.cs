    foreach (var a in abc)
    {
       var stackLayout = new StackLayout()
          {
             //// I want to add TapGestureRecognizer on this outer stacklayout
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
                            new Label { Text = a.Name}}
                          },
                      new StackLayout() {
                         HorizontalOptions = LayoutOptions.EndAndExpand,
                         Orientation = StackOrientation.Horizontal,
                         Children = {
                            new Label { Text = a.Count},
                            new Image { Source = "right1.png" }
                         }
                      }
                   }
                }
             }
           };
    
       var tgr = new TapGestureRecognizer();
       tgr.Tapped += (s,e) => OnTgrClicked();
       stackLayout.GestureRecognizers.Add(tgr);
    
       var viewCell = new ViewCell 
       { 
          View = stackLayout;
        };
        tableSection.Add(viewCell);
    }
