        private void fileGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            foreach (var item in fileGrid.Rows)
                        {
                            if (item.IsMouseOver)
                            {
                                fileGrid.SelectedIndex = item.Index;
                                break;
                            }
                        }
    //Then do what you want to do.
        }
