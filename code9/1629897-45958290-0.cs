        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            SetTileBarColours();
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                // Update Media Position on page leave from Media Player 
                if (rootFrame.SourcePageType.Name == "MediaPlayer")
                {
                    MediaPlayer page = (MediaPlayer)rootFrame.Content;
                    MediaPlayerVM viewModel = (MediaPlayerVM)page.DataContext;
                    viewModel.SavePostion();
                }
                e.Handled = true;
                rootFrame.GoBack();
            }
        }
