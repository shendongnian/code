            public bool Visible = false;
            private async void DataGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                if (Visible == false)
                {
                    await Task.Delay(1); //ensures DataGrid.SelectedIndex is what I just clicked, not the previous value
                    if (DataGrid.SelectedIndex == prevSelectedIndex)
                    { //check if I'm clicking on what's already selected
                        DataGrid.SelectedIndex = 1; //collapses everything
                    }
                    prevSelectedIndex = DataGrid.SelectedIndex; //save current selected index
                    Visible = true;
                }
                else
                {
                    await Task.Delay(1); //ensures DataGrid.SelectedIndex is what I just clicked, not the previous value
                    if (DataGrid.SelectedIndex == prevSelectedIndex)
                    { //check if I'm clicking on what's already selected
                        DataGrid.SelectedIndex = -1; //collapses everything
                    }
                    prevSelectedIndex = DataGrid.SelectedIndex; //save current selected index
                    Visible = false;
                }
            }
