        public static ContentControl CreateControl(string title, Uri path)
        {
            //Create your image
            BitmapImage bitmapImage = new BitmapImage(path);
            Image image = new Image()
            {
                Source = bitmapImage
            };
            //Create your Text
            TextBlock textB = new TextBlock()
            {
                Text = title
            };
            //Put them together
            StackPanel content = new StackPanel();
            content.Children.Add(image);
            content.Children.Add(textB);
            //Add this to the content control
            return new ContentControl()
            {
                Content = content
            };
        }
