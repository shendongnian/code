    public class MovieItem : Grid
    {
        public MovieItem()
        {
            RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            Image image = new Image();
            image.Stretch = Stretch.UniformToFill;
            image.SetBinding(Image.SourceProperty, new Binding(nameof(ImageSource)) { Source = this });
            Children.Add(image);
            TextBlock title = new TextBlock();
            title.FontSize += 1;
            title.FontWeight = FontWeights.Bold;
            title.Foreground = Brushes.Beige;
            title.TextTrimming = TextTrimming.CharacterEllipsis;
            title.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title)) { Source = this });
            Grid.SetRow(title, 1);
            Children.Add(title);
            TextBlock year = new TextBlock();
            year.Foreground = Brushes.LightGray;
            year.TextTrimming = TextTrimming.CharacterEllipsis;
            year.SetBinding(TextBlock.TextProperty, new Binding(nameof(Year)) { Source = this });
            Grid.SetRow(year, 2);
            Children.Add(year);
            TextBlock releaseDate = new TextBlock();
            releaseDate.Foreground = Brushes.LightGray;
            releaseDate.TextTrimming = TextTrimming.CharacterEllipsis;
            releaseDate.SetBinding(TextBlock.TextProperty, new Binding(nameof(ReleaseDate)) { Source = this });
            Grid.SetRow(releaseDate, 3);
            Children.Add(releaseDate);
        }
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(MovieItem), new PropertyMetadata(null));
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MovieItem), new PropertyMetadata(null));
        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(string), typeof(MovieItem), new PropertyMetadata(null));
        public static readonly DependencyProperty ReleaseDateProperty =
            DependencyProperty.Register("ReleaseDate", typeof(string), typeof(MovieItem), new PropertyMetadata(null));
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public string Year
        {
            get { return (string)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }
        public string ReleaseDate
        {
            get { return (string)GetValue(ReleaseDateProperty); }
            set { SetValue(ReleaseDateProperty, value); }
        }
    }
