     public override DependencyObject GetControl(HtmlFragment fragment)
        {
            var node = fragment as HtmlNode;
            MediaElement play = new MediaElement();
            if (node != null)
            {
                Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                localSettings.Values["itson"] = null;
                string src = GetIframeSrc(node).ToString();
                string id = GetVideoId(src);
                string check = "";
                var grid = new Grid
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
            };
                grid.Tapped += async (sender, e) =>
                {
                    play.HorizontalAlignment = HorizontalAlignment.Stretch;
                    if (localSettings.Values["itson"] == null || id != check)
                    {
                            var url = await YouTube.GetVideoUriAsync(id, YouTubeQuality.Quality360P);
                            play.Source = url.Uri;
                            localSettings.Values["qv"] = "360";
                        }
                        check = id;
                        play.AreTransportControlsEnabled = true;
                        localSettings.Values["itson"] = "true";
                        play.Play();
                    }
                };
                grid.PointerEntered += (sender, e) =>
                {
                    Window.Current.CoreWindow.PointerCursor = _handCursor;
                };
                grid.PointerExited += (sender, e) =>
                {
                    Window.Current.CoreWindow.PointerCursor = _arrowCursor;
                };
                AddColumn(grid);
                AddColumn(grid);
                AddColumn(grid);
                var screenShot = GetImageControl((i) => SetScreenshot(i, node));
                Grid.SetColumn(screenShot, 0);
                Grid.SetColumnSpan(screenShot, 3);
                grid.Children.Add(screenShot);
                var player = GetImageControl((i) => i.Source = GetPlayerImage());
                Grid.SetColumn(player, 1);
                grid.Children.Add(player);
                Grid.SetColumn(play, 0);
                Grid.SetColumnSpan(play, 4);
                grid.Children.Add(play);
                return grid;
            }
            return null;
        }
