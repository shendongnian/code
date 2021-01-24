	public sealed class DeepObservableCollection<T>
		: ObservableCollection<T> where T : INotifyPropertyChanged {
		public event PropertyChangedEventHandler ItemPropertyChanged;
		public DeepObservableCollection() {
			CollectionChanged += DeepObservableCollection_CollectionChanged;
		}
		public DeepObservableCollection(ObservableCollection<T> collection)
			: base(collection) {
			CollectionChanged += DeepObservableCollection_CollectionChanged;
		}
		public DeepObservableCollection( List<T> collection )
			: base( collection ) {
			CollectionChanged += DeepObservableCollection_CollectionChanged;
		}
		void DeepObservableCollection_CollectionChanged( object sender, NotifyCollectionChangedEventArgs e ) {
			if ( e.NewItems != null ) {
				foreach ( var item in e.NewItems ) {
					var notifyPropertyChanged = item as INotifyPropertyChanged;
					if ( notifyPropertyChanged != null ) notifyPropertyChanged.PropertyChanged += item_PropertyChanged;
				}
			}
			if ( e.OldItems != null ) {
				foreach ( Object item in e.OldItems ) {
					var notifyPropertyChanged = item as INotifyPropertyChanged;
					if ( notifyPropertyChanged != null ) notifyPropertyChanged.PropertyChanged -= item_PropertyChanged;
				}
			}
		}
		void item_PropertyChanged( object sender, PropertyChangedEventArgs e ) {
			NotifyCollectionChangedEventArgs a = new NotifyCollectionChangedEventArgs( NotifyCollectionChangedAction.Reset );
			OnCollectionChanged( a );
			ItemPropertyChanged?.Invoke( sender, e );
		}
	}
