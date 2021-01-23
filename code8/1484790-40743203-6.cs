    public class FlipViewDataClass:INotifyPropertyChanged
    {
        //provides the description
        private string desc;
        public string Description
        {
            get { return desc; }
            set { desc = value; RaisePropertyChanged("Description"); }
        }
        //provides the imagePath
        //see the MainPage.Loaded event to see how to use
        private ImageSource image;
        public ImageSource ImagePath
        {
            get { return image; }
            set { image = value; RaisePropertyChanged("ImagePath"); }
        }
        //for the image tap to show description functionality
        private bool isDataVisible;
        public bool IsDataVisible
        {
            get { return isDataVisible; }
            set
            {
                isDataVisible = value;
                if (value)
                    IsDescriptionVisible = true;
                RaisePropertyChanged("IsDataVisible");
            }
        }
        //for hide and show the details pannel and hide and show content based on that
        private bool isDescriptionVisible;
        public bool IsDescriptionVisible
        {
            get { return isDescriptionVisible; }
            set { isDescriptionVisible = value; RaisePropertyChanged("IsDescriptionVisible"); }
        }
        //raises the event to the view if any of these properties change
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
