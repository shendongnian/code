    public class WaterfallDataGroup
    {
        public WaterfallDataGroup(String uniqueId, String title, String imagePath, String description)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Items = new ObservableCollection<WaterfallDataItem>();
        }
        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public ObservableCollection<WaterfallDataItem> Items { get; set; }
        public override string ToString()
        {
            return this.Title;
        }
    }
    
