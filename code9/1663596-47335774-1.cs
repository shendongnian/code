    public class MyBindingList<T>:BindingList<T>
    {
        public bool EnableChangeNotifications { get; set; }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if(EnableChangeNotifications)
                base.OnListChanged(e);
        }
    }
