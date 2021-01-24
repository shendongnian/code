    private void bgWorker_doWork(object sender, DoWorkEventArgs e)
    {
        searchBar.Text= "src\\loader.gif", "Loading...";
        
        movieList = new Movies(searchText).movieList;
        
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
