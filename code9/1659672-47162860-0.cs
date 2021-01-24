    public class DirectoryButton : Button
    {
        public DirectoryButton(string name, string content)
        {
            Name = name.Replace(" ", "");
            //Content = new BitmapImage(new Uri("../Resources/folder-icon.png", UriKind.Relative)) + content;
            //Content = new BitmapImage(new Uri("../Resources/folder-icon.png", UriKind.Relative));
            var img = new BitmapImage(new Uri("../Resources/folder-icon.png", UriKind.Relative));
            var sp = new UniformGrid
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Columns = 3,
                Rows = 1
            };
            sp.Children.Add(new Label());
            sp.Children.Add(new Label { Content = content, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center });
            sp.Children.Add(new Image { Source = img, HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center });
            //sp.Orientation = Orientation.Horizontal;
            Content = sp;
            //Content = content;
            Margin = new Thickness(0, 5, 0, 5);
            Height = 65;
            Width = 350;
            FontWeight = FontWeights.Bold;
            Foreground = new SolidColorBrush(Colors.Black);
            Background = new SolidColorBrush(Colors.Gray);
            HorizontalContentAlignment = HorizontalAlignment.Stretch; //<--
            VerticalAlignment = VerticalAlignment.Center;
            Visibility = Visibility.Visible;
        }
