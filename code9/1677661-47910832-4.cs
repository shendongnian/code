    public class Media : IResourceModel<MediaFiles>, IResourceModel<IFiles>
    {
        public MediaFiles Files { get; set; }
        IFiles IResourceModel<IFiles>.Files
        {
            get { return Files; }
            set { Files = (MediaFiles)value; } // <--- Cautious! Check type in production code.
        }
    }
