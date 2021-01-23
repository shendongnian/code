            private void GridRowSplitter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GridContent.RowDefinitions[0].Height = new GridLength(200, GridUnitType.Star);
            GridContent.RowDefinitions[1].Height = new GridLength(3, GridUnitType.Pixel);
            GridContent.RowDefinitions[2].Height = new GridLength(0,GridUnitType.Star);
        }
