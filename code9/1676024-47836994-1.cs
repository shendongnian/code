		private ObservableCollection<BO.MyObject> boCollection;
		public ObservableCollection<BO.MyObject> BoCollection
		{
			get { return boCollection; }
			set
			{
				folderEmails = value;
				NotifyPropertyChanged(m => m.BoCollection);				
			}
		}
