    public class MyDataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string myLabel;
        public string MyLabel
        {
            get { return myLabel; }
            set
            {
                if (value != myLabel)
                {
                    myLabel = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("MyLabel"));
                }
            }
        }
        private string myImage;
        public string MyImage
        {
            get { return myImage; }
            set
            {
                if (value != myImage)
                {
                    myImage = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("MyImage"));
                }
            }
        }
        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (value != selected)
                {
                    selected = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
                }
            }
        }
    }
