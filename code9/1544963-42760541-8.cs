    using using System.Collections.ObjectModel;
    public class MyViewModel
    {
        //add implementation of INotifyPropertyChange & propfull
        public ObservableCollection<MyItem> MySrcList { get; set; }
        //add implementation of INotifyPropertyChange & propfull
        public MyItem SelectedItem { get; set; }
    }
