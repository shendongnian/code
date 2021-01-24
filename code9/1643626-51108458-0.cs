        private readonly object _myDataLock = new object();
        private FastObservableCollection<My20FieldsDataRecord> MyList = new FastObservableCollection<My20FieldsDataRecord>();
		private CollectionViewSource MyListCollectionView = new CollectionViewSource();
		public MyViewModelConstructor() : base()
		{
            // Other ctor code 
			// ...
			// assign the data source of the collection views
			MyListCollectionView.Source = MyList;   			
			
			// Setup synchronization
            BindingOperations.EnableCollectionSynchronization(MyList, _myDataLock);
		}
		
		private async void LoadMyList()
		{
					// load the list
					await Task.Run(async () =>
						{
							MyList.ReplaceAll(await MyRepository.LoadMyList());
						}
					);		
		}
		
