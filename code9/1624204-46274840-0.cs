    List<Place> placeList = new List<Place>();
    public class Place
    {
    private string _Program;
		private string _Name;
		public int _NoOfRaces
		{ get; set; }
		public string Program
		{ get { return _Program; } }
		public string Name
		{ get { return _Name; } }
		public Place(string pKey, string pValue)
		{
			_Program = pKey;
			_Name = pValue;
		}
		public void setNoOfRaces(int pRaces)
		{
			_NoOfRaces = pRaces;
		}
    }
