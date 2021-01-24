    var myData = new ObservableCollection<User>(FormOfAddData.MyList);
    dataGrid.ItemsSource = myData;
    
    private void OnButtonClick(){
      User user = dataGrid.SelectedItem as User;
      if(user != null){
        myData.Remove(user);
      }
    }
