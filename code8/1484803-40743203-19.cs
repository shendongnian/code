     public class WaterfallDataItem:INotifyPropertyChanged
    {
        public WaterfallDataItem(String uniqueId, String title, String imagePath, String description, String content)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Content = content;
        }
        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Content { get; private set; }
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
        public override string ToString()
        {
            return this.Title;
        }
    }
