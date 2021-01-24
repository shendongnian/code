    public class AssetTrackerViewModel
    {
       public AssetTrackerViewModel()
       {
         AssetTrackers = new List<AssetTracker>();
       }
       public IEnumerable<AssetTracker> AssetTrackers {get;set}
    }
