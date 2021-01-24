    var dataSource = new BindingList<TreeListItem>();
    for (int i = 0; i < 170000; i++)
    {
        dataSource.Add(new TreeListItem() { ID = i, ParentID = i % 3 });
    }
    treeList1.DataSource = dataSource;
    
----------
    public class TreeListItem
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string SomeProperty { get; set; }
    }
