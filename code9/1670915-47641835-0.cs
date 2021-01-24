    private void ShowImage(Button button)
        {
            string buttonName = button.Name;
            string path = "/MyProject;component/Images/{buttonName}.png";
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            button.Content = image;
        }
