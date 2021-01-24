	public class Station
	{
		private string _stationCode;
		public Station(string stationCode)
		{
			_stationCode = stationCode;
		}
		public string StationCode
		{
			get { return _stationCode; }
            // Optional: provide setter here
		}
	}
