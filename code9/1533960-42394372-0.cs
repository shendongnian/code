	public class PagingCollectionView : CollectionView
	{
		private readonly int _itemsPerPage;
		private int _currentPage = 1;
		public PagingCollectionView(IEnumerable innerList, int itemsPerPage)
			: base(innerList)
		{
			this._itemsPerPage = itemsPerPage;
		}
		public int FilteredCount
		{
			get {return FilteredCollection.Count(); }
		}
		private IEnumerable<object> FilteredCollection => this.SourceCollection.OfType<object>().Where(o=>Filter(o));
		public override int Count
		{
			get
			{
				if (FilteredCount == 0) return 0;
				if (this._currentPage < this.PageCount) // page 1..n-1
				{
					return this._itemsPerPage;
				}
				else // page n
				{
					var itemsLeft = FilteredCount % this._itemsPerPage;
					if (0 == itemsLeft)
					{
						return this._itemsPerPage; // exactly itemsPerPage left
					}
					else
					{
						// return the remaining items
						return itemsLeft;
					}
				}
			}
		}
		public int CurrentPage
		{
			get { return this._currentPage; }
			set
			{
				this._currentPage = value;
				this.OnPropertyChanged(new PropertyChangedEventArgs("CurrentPage"));
			}
		}
		public int ItemsPerPage { get { return this._itemsPerPage; } }
		public int PageCount
		{
			get
			{
				return (FilteredCount + this._itemsPerPage - 1)
					/ this._itemsPerPage;
			}
		}
		private int EndIndex
		{
			get
			{
				var end = this._currentPage * this._itemsPerPage - 1;
				return (end > FilteredCount) ? FilteredCount : end;
			}
		}
		private int StartIndex
		{
			get { return (this._currentPage - 1) * this._itemsPerPage; }
		}
		public override object GetItemAt(int index)
		{
			var offset = index % (this._itemsPerPage);
			return this.FilteredCollection.ElementAt(this.StartIndex + offset);
		}
		public void MoveToNextPage()
		{
			if (this._currentPage < this.PageCount)
			{
				this.CurrentPage += 1;
			}
			this.Refresh();
		}
		public void MoveToPreviousPage()
		{
			if (this._currentPage > 1)
			{
				this.CurrentPage -= 1;
			}
			this.Refresh();
		}
	}	
