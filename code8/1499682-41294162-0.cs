    StackPanel[] allGrids = { Grid_1, Grid_2, Grid_3, Grid_4, ... }; //Replace StackPanel with the
    //type of control you are using, e.g. Grid or WrapPanel. 
    foreach (StackPanel grid in allGrids)
    {
        grid.Visibility = Visibility.Collapsed; //collapse all grids
    }
    allGrids[(your listview/other control).SelectedIndex].Visibility = Visibility.Visible;
    //make the grid you need visible
