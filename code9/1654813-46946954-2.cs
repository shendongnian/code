    MyListView.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
                {
                    if (e.PropertyName == "ItemsSource")
                    {
                        try
                        {
                            if (MyListView.ItemsSource != null)
                            {
                                var tmp = (IList)MyListView.ItemsSource;
                                MyListView.HeightRequest = tmp.Count * MyListView.RowHeight;
                            }
                        }
                        catch (Exception ex)
                        {
                            ex.Track();
                        }
                    }
                };
