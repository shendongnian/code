    public class TreeItem
    {
        public string Header { get; set; }
        public IEnumerable<TreeItem> Childs { get; set; }
    }
        var items = new List<TreeItem>
        {
            new TreeItem
            {
                Header = "This is the root",
                Childs = new[]
                {
                    new TreeItem {Header = "Child item 1"},
                    new TreeItem {Header = "Child item 2"}
                }
            }
        };
        treeViewSL.ItemsSource = items;
