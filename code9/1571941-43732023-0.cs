    var scroll = new ScrollView();
    var stack = new StackLayout();
    
    stack.Children.Add(new BoxView { BackgroundColor = Color.Red,   HeightRequest = 600, WidthRequest = 600 });
    
    stack.Children.Add(new Entry());
    
    scroll.Content = stack;
    
    Content = scroll;
