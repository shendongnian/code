    private ObservableCollection<Movies> MoviesCol { get; set; }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        List<Movies> ml = new List<Movies>();
        dataGridMovies.DataContext = ml;
        Movies check = new Movies() { Title = "title", Director = "director", Score = "score", Type = "type" };
        Movies check1 = new Movies() { Title = "title1", Director = "director1", Score = "score1", Type = "type1" };
        Movies check2 = new Movies() { Title = "title2", Director = "director2", Score = "score2", Type = "type2" };
        MoviesCol.Add(check1);
        MoviesCol.Add(check);
        dataGridMovies.ItemsSource = MoviesCol;
        MoviesCol.Add(check2);
    }
