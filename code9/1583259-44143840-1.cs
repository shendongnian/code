    public class DatabaseItem
    {
        // All other properties
        string padViewPointsString;
        public string PadViewPointsString
        {
            get => padViewPointsString;
            set
            {
                padViewPointsString = value;
                PadViewPoints = JsonConvert.DeserializeObject<Xamarin.Forms.Point[]>(value);
            }
        }
        public Xamarin.Forms.Point[] PadViewPoints { get; set; }
    }
