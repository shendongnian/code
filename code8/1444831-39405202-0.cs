    public class AccessoryListView : ListView
    {
       public delegate void OnAccessoryTappedDelegate();
       public OnAccessoryTappedDelegate OnAccessoryTapped { get; set; }
    }
