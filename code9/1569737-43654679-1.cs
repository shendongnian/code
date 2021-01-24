    <MenuItem
        Header="Draggable"
        IsCheckable="True"
        Checked="MenuItem_Checked" Unchecked="MenuItem_Unchecked" />
----------
    private void MenuItem_Unchecked(object sender, RoutedEventArgs e)
    {
        this.IsDraggable = false;
    }
    private void MenuItem_Checked(object sender, RoutedEventArgs e)
    {
        this.IsDraggable = true;
    }
