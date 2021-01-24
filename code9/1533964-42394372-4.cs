	public class VM:BindableBase
	{
		public VM()
		{
			PagingCollectionView = new PagingCollectionView(
				Enumerable.Range(300, 1000).Select(i => i.ToString("X")),
				5);
			PagingCollectionView.Filter = (o) => string.IsNullOrWhiteSpace(Filter) || o.ToString().StartsWith(Filter);
			Next = new DelegateCommand(PagingCollectionView.MoveToNextPage);
			Previous = new DelegateCommand(PagingCollectionView.MoveToPreviousPage );
		}
		private string _Filter;
		public string Filter
		{
			get { return _Filter; }
			set {
				if(SetProperty(ref _Filter, value))
					PagingCollectionView.Refresh();
			}
		}
		public PagingCollectionView PagingCollectionView { get; set; }
		public DelegateCommand Next { get; set; }
		public DelegateCommand Previous { get; set; }
	}
