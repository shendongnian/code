	public class TaxesObservableCollection<T> : ObservableCollection<T> // Think about to implement INotifyPropertyChanged too, I guess it will be usefull
	{
		public TaxesObservableCollection(IEnumerable<T> collection, string taxGroupName) : base(collection)
		{
			TaxGroupName = taxGroupName;
		}
		
		private bool taxGroupName;
		public bool TaxGroupName
		{
			get { return taxGroupName; }
			set { taxGroupName = value; }
		}
	}
