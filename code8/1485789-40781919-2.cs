    public class BlankPage6ViewModel
    {
        public BlankPage6ViewModel()
        {
            MyItems = new ObservableCollection<IDModel>();
            for (int i = 0; i < 50; i++)
            {
                MyItems.Add(new IDModel { ID = i, Name = "Name " + i });
            }
        }
    
        public ObservableCollection<IDModel> MyItems { get; set; }
    }
    
    public class IDModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
