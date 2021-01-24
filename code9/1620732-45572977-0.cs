    public class MainWindowViewModel
    {
        public void SetupCollectionView(IEnumerable<MyObject> entities)
        {
            foreach(var entity in entities)
            {
                CollectionViewSource.GetDefaultView(entity)
                    .SortDescriptions.Add(new SortDescription(nameof(MyObject.Header), ListSortDirection.Ascending));
                this.SetupCollectionView(entity.Childs);
            }
        }
    }
    public class MyObject
    {
        public string Header { get; set; }
        public int AnotherProperty { get; set; }
        public virtual IEnumerable<MyObject> Childs { get; set; }
    }
