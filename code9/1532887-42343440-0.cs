    var ButtonHolder = new Button {
                            Text = "Requirements",
                            BackgroundColor = Color.Orange,
                            TextColor = Color.White
                        };
    ButtonHolder.SetBinding (Button.CommandProperty, "GoDashboardCommand");
    grid.Children.Add(ButtonHolder, 0, 1);
