      public class Foo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string GivenNames { get; set; }
        public int Id { get; set; }
    }
     public class FooViewModel : Foo
    {
        public bool SaveNeeded { get; set; }
        public void NoticeChanges()
        {
            PropertyChanged += FooViewModel_PropertyChanged;
        }
        private void FooViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveNeeded = true;
        }
    }
