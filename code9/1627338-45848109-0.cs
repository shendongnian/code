    public class PJDataContext
    {
        public ObservableCollection<GroupEvent> EventList { get; }
            = new ObservableCollection<GroupEvent>();
        public void AddGroupEvent(GroupEvent ge)
        {
            EventList.Add(ge);
        }
    }
