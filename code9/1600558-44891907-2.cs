    public class Item
    {
        public string key;
        public object obj;
        public Item(string k, object o) { k = key; o = obj; }
    }
    class MyCache
    {
        LinkedList<Item> ll = new LinkedList<Item>();
        LinkedListNode<Item> node;
        Dictionary<string, LinkedListNode<Item>> dd = new Dictionary<string, LinkedListNode<Item>>();
        int capacity = 5;     //just for simplicity set capacity for caching
        //here you Add new object
        public void Add(string key, object obj)
        {
            if (cap == 0) return; 
            //check if you already have that object
            if (!dd.TryGetValue(key, out node)) 
            {
                //if capacity exceeded- remove object from beginig of LinkedList
                if (dd.Count >= capacity) 
                    RemoveItem();
                Item item = new Item(key, obj);
                LinkedListNode<Item> newNode = new LinkedListNode<Item>(item);
                ll.AddLast(newNode);
                dd.Add(key, newNode);
                return;
            }
            //we move that object to the end of the list
            ll.Remove(node);
            ll.AddLast(node);
        }
        // remove object from LinkedList and Dictionary
        void RemoveItem()
        {
            LinkedListNode<Item> node = ll.First;
            ll.Remove(node);
            dd.Remove(node.Value.key);
        }
        public object Get(string key)
        { 
            //if we have that object, we return it and move to the end of LList           
            if (dd.TryGetValue(key, out node))
            {
                ll.Remove(node);
                ll.AddLast(node);
                return node.Value.obj;
            }
            else return default(object);
        }
    }
