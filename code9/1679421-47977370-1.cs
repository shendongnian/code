    ObservableCollection<string> dataList = new ObservableCollection<string>();
    
    int selectedIndex = 0;
    
    public MainPage()
    {
    	InitializeComponent();
    
        for (int i=0; i<10; i++)
        {
            dataList.Add("item" + i);
        }
    
        myListView.ItemsSource = dataList;
    
        myListView.ItemSelected += MyListView_ItemSelected;
    
        MyBtn.Clicked += MyBtn_Clicked;
    }
    
    private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //try to do something
    }
    
    private void MyBtn_Clicked(object sender, EventArgs e)
    {
        if (selectedIndex == dataList.Count) selectedIndex = 0;
        myListView.SelectedItem = dataList[selectedIndex++];
    }
