    foreach (var user in usersFromDb)
                {
                    var canvas = new Canvas
                    {
                        Width = 1080,
                        Height = 70
                    };
    
                    var canavasThickness = canvas.Margin;
                    canavasThickness.Top = spacer;
                    canvas.Margin = canavasThickness;
                    canvas.VerticalAlignment = VerticalAlignment.Top; // <------ THIS IS THE SOLUTION <-------- //
                    UserGrid.Children.Add(canvas);
    
                    var button = new Button
                    {
                        Width = 1080,
                        Height = 70,
                        FontSize = 20,
                        Content = $"{user.Name} {user.Surname}",
                        Background = Brushes.Azure,
                        Foreground = Brushes.Black
                    };
    
                    canvas.Children.Add(button);
    
                    spacer += 150;
                }
