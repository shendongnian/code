    public class MyClass1
    {
        public int Code { get; set; }
        public List<MyItem> Items { get; set; }
        public void AddItem(MyItem item)
        {
            if (item == null) throw new ArgumentNullException();
            item.ParentClassCode = Code;
            Items.Add(item);
        }
    }
