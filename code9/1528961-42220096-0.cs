    listView = new ListView();
    ObservableCollection<String> list = new ObservableCollection<string>();
    list.Add("1");
    list.Add("2");      
    listView.ItemsSource = list;
    
    listView2 = new ListView();
    ObservableCollection<String> list12 = new ObservableCollection<string>();
    list12.Add("11");
    list12.Add("12");
    listView2.ItemsSource = list12;
    
    Dictionary<string,ObservableCollection<String>> dictionary = new Dictionary<string,ObservableCollection<String>();
    dictionary.Add(nameof(list), list);
    dictionary.Add(nameof(list12),list12);
    
    combobox.ItemsSource = dictionary;
    //And make sure you add DisplayMemberPath="Key" in the combobox.
    
    private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       var combobox = sender as ComboBox;
       if(combobox.SelectedIndex == 0)
          combobox.ItemsSource = dictionary[nameof(list)];
       else
          combobox.ItemsSource = dictionary[nameof(list12)];
    
       //Clear the DisplayMemberPath since you're binding the values now.
       combobox.DisplayMemberPath  = null;
    }
