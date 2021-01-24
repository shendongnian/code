    var scroll = new ScrollView();
    var stack = new StackLayout();
    
    stack.Children.Add(new BoxView { BackgroundColor = Color.Red,   HeightRequest = 600, WidthRequest = 600 });
    
    stack.Children.Add(new Entry());
    
    // Note how I add the stack object to the ScrollView here
    scroll.Content = stack;
    
    // And add the ScrollView to the Content of the page instead of the stack
    Content = scroll;
