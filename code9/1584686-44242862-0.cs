     public Class Students
     {
		  public int sid { get; set; }
          public string Name { get; set; }  
     } 
     listview.ItemSelected += Lst_ItemSelected;
     private void Lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
      {
	       var index = (listview.ItemsSource as List<Students>).IndexOf(e.SelectedItem as Students); // to get a             index value or postion value 
	       ((ListView)sender).SelectedItem = null;
     
    }
