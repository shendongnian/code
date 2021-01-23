    // Used a shortened version of the name for the example here
    public class AssetItem
    {
        public AssetItem(AssetItem other)
        {
            // COPY the contents of other to your "this" instance one element at a time.
            // Don't try assigning over "this"
        }
    }
    public class ItemDetailViewModel : Models.AssetItem
    {
        public ItemDetailViewModel()
        {
        }
        public ItemDetailViewModel(Models.AssetItem model)
            : base(model)
        {
            // Your superclass is "set up" already by now
        }
    
            // Other Properties & Methods for View Models
    
    }
