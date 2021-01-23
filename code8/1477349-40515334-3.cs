     private void AddToFavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            //your dynamic text set to textblock
            StringTextBlock.Text = myDynamicText;  
            //Set value of your text to member variable of the model/class
            favourites f = new favourites();
            f.myText = myDynamicText;
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            
            /*Check if "FavouritesList" key is present in IsolatedStorageSettings
              which means already a list had been added. If yes, retrieve the
              list, compare each item with your dynamic text, add or remove
              accordingly and replace the new list in IsolatedStorageSettings
              with same key. */
            if (settings.Contains("FavouritesList"))
            {
                List<favourites> l = (List<favourites>)settings["FavouritesList"];
                for(int i = 0; i <= l.Count()-1; i++)
                {
                    if (l[i].Equals(myDynamicText))
                    {
                        l.RemoveAt(i);
                        settings["FavouritesList"] = l;
                    }
                    else
                    {
                        l.Add(f);
                        settings["FavouritesList"] = l;
                    }
                }           
            }
            //If no key in IsolatedStorageSettings means no data has been added
            //in list and IsolatedStorageSettings. So add new data
            else
            {
                List<favourites> l = new List<favourites>();
                l.Add(f);
                settings["FavouritesList"] = l;
            }
            settings.Save();
        }       
    
