    protected GalerieViewModel ViewModel {
        get { return (GalerieViewModel)this.DataContext; }
    }
    private void MenuItem_Click(Object sender, RoutedEventArgs e)
    {
        IGalerieModel selectedItem = this.Images.SelectedItem as IGalerieModel;
        if( selectedItem != null )
        {
             this.ViewModel.Images.Remove( selectedItem );
        }
    }
