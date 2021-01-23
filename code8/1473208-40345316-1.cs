      public class Example : Form
      {
        Node _node;
    
        public Example()
        {
          _node = new Node();
          _node.MyEvent += _node_MyEvent; // This will cause the BinaryFormatter to try to serialize Example form when serializing _node - unless [field: NonSerialized] attribute is used.
        }
    
        private void _node_MyEvent(object sender, EventArgs e)
        {
          
        }
      }
    
      [Serializable]
      public class Node
      {
        [field: NonSerialized]
        public event EventHandler MyEvent;
      }
