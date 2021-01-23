     IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("FavouritesList"))
            {
               List<favourites> l = (List<favourites>)settings["FavouritesList"];
                if(l.Count!= 0)
                {
                    FavoriteListBox.ItemsSource = l;
                }                  
            }
           
