    private async void DataGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        ClickedRowDetails = false; //default assume that we haven't clicked row details
        await Task.Delay(1); //wait for other events to fire
        if (!ClickedRowDetails) { 
            if (DataGrid.SelectedIndex == prevSelectedIndex )
            {
                DataGrid.SelectedIndex = -1;
            }
            prevSelectedIndex = DataGrid.SelectedIndex;
        }
    }  
