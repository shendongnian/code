    private bool isRotated = false;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (!isRotated)
        {
            myGrid.LayoutTransform = new RotateTransform(90, myGrid.ActualWidth / 2, myGrid.ActualHeight / 2);
        }
        else
        {
            myGrid.LayoutTransform = Transform.Identity;
        }
        isRotated = !isRotated;
    }
