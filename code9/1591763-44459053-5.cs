    class ItemSource: INotifyPropertyChanged 
    {
    	public int Id {get { ... } set { ...; OnPropertyChanged("Id"); }}
    	public bool ItemIsInTable {get { ... } set { ...; OnPropertyChanged("ItemIsInTable"); }}
    	....
    }
