    public class SimpleCloudHandler : MonoBehaviour, ICloudRecoEventHandler
    {
        public string metaData_Content;
        public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult)
        {
            metaData_Content = targetSearchResult.MetaData;
        }
    }
