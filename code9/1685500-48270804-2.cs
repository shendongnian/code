		class DataSource : INotifyPropertyChanged
		{
			public ObservableCollection<HistoricalStandingsData> Items { get; } = new ObservableCollection<HistoricalStandingsData>();
			public HistoricalStandingsData SelectedItem
			{
                // Information on selection is stored in items themselves, use Linq to find the single matching item
				get => Items.Where(x => x.Selected).SingleOrDefault();
				set
				{
                    // Reset previous selection
					var item = SelectedItem;
					if (item != null)
						item.Selected = false;
                    // Mark new item as selected, raising HistoricalStandingItem.PropertyChanged
					if (value != null)
						value.Selected = true;
                    // Notify observers that SelectedItem changed
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
				}
			}
           
            // From INotifyPropertyChanged
			public event PropertyChangedEventHandler PropertyChanged;
			public DataSource()
			{
                // Helper ICommand used for appending new items to HistoricalStandingsData
				AddNew = new Command(() =>
				{
					var item2 = new HistoricalStandingsData(DateTime.Now.ToString());
                    // Append, notifies observers that collection has changed.
					Items.Add(item2);
                    // Set as selected, resetting previous selection
					SelectedItem = item2;
				});
			}
			public ICommand AddNew { get; } 
		}
