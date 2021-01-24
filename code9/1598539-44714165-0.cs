            var textRun = new Run("Hii, my name is Ajay!!");
            textRun.BaselineAlignment = BaselineAlignment.Center;
            @out.Inlines.Add(textRun);
            Image emo = new Image();
            emo.Height = 20;
            emo.Width = 20;
            emo.VerticalAlignment = VerticalAlignment.Bottom;
            emo.Margin = new Thickness(3, 0, 0, 0);
            emo.Source = new BitmapImage(new Uri(@"C:\Users\admin\Desktop\test1.jpg", UriKind.RelativeOrAbsolute));
           // InlineUIContainer container = new InlineUIContainer(emo);
            @out.Inlines.Add(emo)
 
