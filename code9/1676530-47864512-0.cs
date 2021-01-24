    Class MyClass
    {
        ObservableCollection<pojo> myCollection {get;set;}
        MyClass()
        {
            calendarmstrDG.DataContext = myCollection;
        }
        public void AddData()
        {
            myCollection.Add(new pojo(){ // Add Values });
        }
        public void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            foreach(pojo items in myCollection)
            {
                // here get items using items.Prefix/year/....
            }
        }
    }
