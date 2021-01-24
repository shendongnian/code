	public class MyPageViewModel
	{
		/*
		 * This does not have to be Observable. Any IEnumerable will work just fine.
		 * We make this Observable so that any changes to the Collection will update
		 * our View. It's also worth noting that any changes to a single item in our
		 * Collection would not update in our View as our Model does not implement
		 * `INotifyPropertyChanged`. 
		 */
		public ObservableCollection Percentanges { get; set; }
	}
