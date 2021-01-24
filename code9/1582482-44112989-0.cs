    var test = new List<Product>
    {
        new Product() {Text1 = "DESC", Text2= "HelloWorld" },
        new Product() {Text1 = "DESC2", Text2= "HelloWorld2" }
    };
    
    MyGrid.BackgroundColor = Color.Yellow;
    
    var Name = new Label { Text = test[0].Text1.ToString(), TextColor = Color.Black, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
    var Desc = new Label { Text = test[0].Text2.ToString(), TextColor = Color.Black, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
    
    var MyLayout = new StackLayout();
    MyLayout.BackgroundColor = Color.Red;
    MyLayout.Children.Add(Name);
    MyLayout.Children.Add(Desc);
    MyGrid.Children.Add(MyLayout, 0, 0);
    
    var Name2 = new Label { Text = test[0].Text1.ToString(), TextColor = Color.Black, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
    var Desc2 = new Label { Text = test[0].Text2.ToString(), TextColor = Color.Black, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
    
    var MyLayout2 = new StackLayout();
    MyLayout2.BackgroundColor = Color.Blue;
    MyLayout2.Children.Add(Name2);
    MyLayout2.Children.Add(Desc2);
    MyGrid.Children.Add(MyLayout2, 1, 0);
