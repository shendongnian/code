    public class AssetTrackersViewModel
    {
       public AssetTrackersViewModel()
       {
         AssetTrackers = new List<AssetTracker>();
       }
       public IEnumerable<AssetTracker> AssetTrackers {get;set}
    }
