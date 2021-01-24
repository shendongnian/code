    //Models
    
    public class Manager
    {
        public Item MyItem { get; set; }
        public void Recalculate(){ ... } 
    }
    public class Item
    {
        public string SomeProperty { get; set; }
    }
    //ViewModels
    public class ManagerViewModel
    {
        public Manager Model { get; set; }
        public ItemViewModel MyItem { get; set; }
        public ManagerViewModel()
        {
            //Listen for property changes inside MyItem
            MyItem.PropertyChanged += ItemPropertyChanged;
        }
        //Whenever a Property gets updated inside MyItem, run Recalculate() inside the Manager Model 
        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Model.Recalculate();
        }
    }
    public class ItemViewModel
    {
        public Item Model { get; set; }
        public string SomeProperty
        {
            get => Model.SomeProperty;
            set 
            { 
                Model.SomeProperty = value;
                RaisePropertyChanged("SomeProperty");
            }
        }
    }
