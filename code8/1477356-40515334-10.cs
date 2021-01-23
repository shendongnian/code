     IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("FavouritesList"))
            {
               List<favourites> l = (List<favourites>)settings["FavouritesList"];
                if(l.Count!= 0)
                {
                    NoData.Visibility = System.Windows.Visibility.Collapsed;
                    FavoriteListBox.Visibility = System.Windows.Visibility.Visible;
                    FavoriteListBox.ItemsSource = l;
                }                  
            }
            else
            {
                FavoriteListBox.Visibility = System.Windows.Visibility.Collapsed;                   
                NoData.Visibility = System.Windows.Visibility.Visible;
            }
