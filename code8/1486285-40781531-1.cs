            Button button = new Button();
            button.Content = "SomeTetx Some text";
            button.Height = 150;
            button.Width = 150;
            grid.Children.Add(button);
            button.Margin = new Thickness(10, 10, 0, 0);
            button.BorderThickness = new Thickness(5);
            // here is the important line:
            button.Style = (Style)Application.Current.FindResource("style_MyButton");
            Image image = new Image();
            var source=new BitmapImage( new Uri (imagepath));
            source.Freeze();
            image.Source = source;
            var brush = new ImageBrush();
            brush.ImageSource = image.Source;
            // this is how you can manipulate the stretch mode:
            brush.Stretch = Stretch.UniformToFill;
            button.Background = brush;
