    public class MyItemViewModel
    {
        public ObservableCollection<TextBlock> Items { get; set; } = new ObservableCollection<TextBlock>();
        public string Title { get; set; }
        public MyItemViewModel(string title)
        {
            Title = title;
            Items.Add(new TextBlock() { Text = "SubItem1" });
            Items.Add(new TextBlock() { Text = "SubItem2" });
            Items.Add(new TextBlock() { Text = "SubItem3" });
        }
    }
