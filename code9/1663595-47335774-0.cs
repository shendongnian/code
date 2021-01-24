    public class MyBindingList<T>:BindingList<T>
    {
        public bool EnableNotificationChanges { get; set; }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if(EnableNotificationChanges)
                base.OnListChanged(e);
        }
    }
