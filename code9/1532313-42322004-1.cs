    private void bgWorker_doWork(object sender, DoWorkEventArgs e)
    {
        var loadingMovie = new Movie("src\\loader.gif", "Loading...");
        movieList = new List<Movie>();
        movieList.Add(loadingMovie); 
        Dispatcher.Invoke(() =>
        {
            searchBar.ItemsSource = movieList;
            searchBar.IsDropDownOpen = true;
        });
    }
    private void bgWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
       if (e.Error != null)
       {
           Dispatcher.Invoke(() =>
           {
               MessageBox.Show(e.Error.ToString());
           });
        }     
    }
