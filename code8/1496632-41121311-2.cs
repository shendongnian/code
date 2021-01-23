	public class ViewModel:BindableBase
	{
		public ViewModel()
		{
			for (int i = 0; i < 200; i++)
			{
				Items.Add(new DataModel()
				{
					Property1 = $"{200 - i}:Prop1",
					Property2 = $"{i}:Prop2"
				});
			}
            //add filter
			CollectionViewSource.Filter += (s, e) =>
			{
				var d = e.Item as DataModel;
				if (d != null)
				{
					e.Accepted = (string.IsNullOrEmpty(Search1) || d.Property1.StartsWith(Search1))//search property 1
								&& (string.IsNullOrEmpty(Search2) || d.Property2.StartsWith(Search2));//search property 2
				}
				else
					e.Accepted = false;
			};
			CollectionViewSource.Source = Items;
		}
		public CollectionViewSource CollectionViewSource { get; } = new CollectionViewSource();
		public ICollectionView View => CollectionViewSource.View;
		private string _Search1;
		public string Search1
		{
			get { return _Search1; }
			set
			{
				if (SetProperty(ref _Search1, value))
					View.Refresh();
			}
		}
		private string _Search2;
		public string Search2
		{
			get { return _Search2; }
			set
			{
				if (SetProperty(ref _Search2, value))
					View.Refresh();
			}
		}
		public ObservableCollection<DataModel> Items { get; } = new ObservableCollection<DataModel>();
	}
