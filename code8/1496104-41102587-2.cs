    private void MenuItem_Click(Object sender, RoutedEventArgs e)
    {
        IGalerieModel selectedItem = this.Images.SelectedItem as IGalerieModel ;
        if( selectedItem != null )
        {
             GalerieViewModel viewModel = (GalerieViewModel)this.DataContext;
             viewModel.Images.Remove( selectedItem );
        }
    }
