    public Context() 
    {
        ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized +=
              (sender, e) => Subscribe(e.Entity as Node);
    }
    public void Subscribe(Node node)
    {
        node?.Subscribe();
    }
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Node Parent { get; set; }
    
        public virtual ObservableCollection<Node> Nodes { get; set; }
    
        public Node()
        {
            Nodes = new ObservableCollection<Node>();
        }
        public void Subscribe()
        {
            Nodes.CollectionChanged += Nodes_CollectionChanged;
        }
    
        private void Nodes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // do something just if the USER adds or romoves item.
        }
    }
