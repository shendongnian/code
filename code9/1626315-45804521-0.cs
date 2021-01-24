    // This is the collection to bind your datagrid to
    public ObservableCollection<YourObject> Data { get; } = new ObservableCollection<YourObject>();
    // This method needs to be called once (preferably in the constructor)
    private void InitDataGrid() 
    {
        dataGrid1.ItemsSource = this.Data;
    }
    private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
    {
        Application.Current.Dispatcher.Invoke((Action)(() =>
        {
            // Here you need to call a method which modifies the Data property.
            // Try removing, inserting, updating the items directly to the collection.
            // Do not set the ItemsSource directly, instead manipulate the ObservableCollection.
        }));
    }
