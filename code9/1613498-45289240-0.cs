    public partial class Buy (...){
        InitalizeComponent();
        Content = GetContent();
    }
    public View GetContent()
    {
        var animalItemIdStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Post ID: "},
                    new Label { Text = "Animal ID"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalUserIdStack = new StackLayout
        {
            Children = {
                    new Label { Text = "user ID: "},
                    new Label { Text = "Posting userID"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalBreedStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Breed: "},
                    new Label { Text = "Animal's breed"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalGenderStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Gender: "},
                    new Label { Text = "Animal's gender"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalAgeStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Age: "},
                    new Label { Text = "Animal's age"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalColorStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Color: "},
                    new Label { Text = "Animal's color"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalPriceStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Price: "},
                    new Label { Text = "Animal's price"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalLocationStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Location: "},
                    new Label { Text = "Animal owner's location"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalEmailStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Location: "},
                    new Label { Text = "Animal's location"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalPhoneStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Phone: "},
                    new Label { Text = "Animal owner's phone"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalDatePostedStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Posted: "},
                    new Label { Text = "Posted date"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalLastEditStack = new StackLayout
        {
            Children = {
                    new Label { Text = "Last Edit: "},
                    new Label { Text = "Last Edited date"}
                },
            Orientation = StackOrientation.Horizontal
        };
        var animalStack = new StackLayout
        {
            Children =
                {
                    animalItemIdStack,
                    animalUserIdStack,
                    animalBreedStack,
                    animalGenderStack,
                    animalAgeStack,
                    animalColorStack,
                    animalPriceStack,
                    animalLocationStack,
                    animalEmailStack,
                    animalEmailStack,
                    animalPhoneStack,
                    animalDatePostedStack,
                    animalLastEditStack
                },
            Orientation = StackOrientation.Vertical
        };
        var animalFrame = new Frame();
        animalFrame.Content = animalStack;
        var listView = new ListView();
        listView.ItemTemplate = new DataTemplate(() =>
        {
            return new ViewCell { View = animalFrame };
        });
        listView.ItemsSource = new List<object>()
                {
                    new object(),
                    new object(),
                    new object(),
                };
        var contentStack = new StackLayout();
        contentStack.Children.Add(listView);
        return contentStack;
    }
