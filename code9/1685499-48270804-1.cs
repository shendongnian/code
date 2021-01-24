		public class HistoricalStandingsData : INotifyPropertyChanged
		{
			public HistoricalStandingsData(string name)
			{
				this.TournamentName = name;
			}
			private bool selected;
			public bool Selected
			{
				get
				{
					return selected;
				}
				set
				{
					selected = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Selected)));
				}
			}
			public string TournamentName { get; }
            // From INotifyPropertyChanged
			public event PropertyChangedEventHandler PropertyChanged;
		}
