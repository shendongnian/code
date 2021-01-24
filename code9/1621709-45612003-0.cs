    public class Item
    {
        private string _TextToDisplay;
        public string Name { get; set; }
        public int UniqNumber { get; set; }
        public string TextToDisplay
        {
            get
            {
                _TextToDisplay  = Name + "-" + UniqNumber;  //Add other modification from converter
                return _TextToDisplay;               
            }
            set
            {
                _TextToDisplay = value;
            }
        }
    }
