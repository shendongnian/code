    private async void Search_Button_Click(object sender, RoutedEventArgs e)
    {
        LoadBar.Visibility = Visibility.Visible;
        var data=await Task.Run(StartSearch(Search_TextBox.Text));
        ListViewData=new ObservableCollection(data);
        //Raise a change notification if `ListViewData` isn't a property
        //or doesn't raise the event itself
        //RaisePropertyChanged("ThatPropertyName);
 
        LoadBar.Visibility = Visibility.Hidden;
    }
