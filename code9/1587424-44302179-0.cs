    class Program
    {
        private static MyCollection Collection;
        private static MyCollectionModifier Modif1;
        private static MyCollectionModifier Modif2;
        static void Main(string[] args)
        {
            Collection = new MyCollection();
            Modif1 = new MyCollectionModifier("Modifier 1", Collection);
            Modif2 = new MyCollectionModifier("Modifier 2", Collection);
            Modif1.AddItem("Test1");
            Modif2.AddItem("Test2");
            Console.ReadKey();
        }
    }
    public class MyCollectionItemAddedEventArgs:EventArgs
    {
        public Object ChangeSource { get; set;}
        public int newIndex {get;set;}
    }
    public delegate void MyCollectionItemAddedEventHandler(object sender, MyCollectionItemAddedEventArgs e);
    public class MyCollection
    {
        private List<String> _myList;
        public  String this[int Index]
        {
            get { return _myList[Index]; }
        }
        public event MyCollectionItemAddedEventHandler ItemAdded;
       public  MyCollection()
        {
            _myList = new List<string>();
        }
        protected virtual void OnMyCollectionItemAdded(MyCollectionItemAddedEventArgs e)
        {
            if (ItemAdded != null)
                ItemAdded(this, e);
        }
        public void AddItem(String Item, object ChangeSource = null)
        {
            _myList.Add(Item);
            var e = new MyCollectionItemAddedEventArgs();
            e.ChangeSource = ChangeSource;
            e.newIndex = _myList.Count;
            OnMyCollectionItemAdded(e);
        }
    }
    public class MyCollectionModifier
    {
        private MyCollection _collection;
        public string Name { get; set; }
        public MyCollectionModifier(string Name, MyCollection Collection)
        {
            this.Name = Name;
            _collection = Collection;
            _collection.ItemAdded += Collection_ItemAdded;
        }
        public void AddItem(string Item)
        {
            _collection.AddItem(Item, this);
        }
        void Collection_ItemAdded(object sender, MyCollectionItemAddedEventArgs e)
        {
            if (e != null)
            {
                if (this.Equals(e.ChangeSource))
                {
                    Console.WriteLine("{0} : I changed the collection", Name);
                }
                else
                {
                    Console.WriteLine("{0} : Somebody else changed the collection", Name);
                }
            }
            
        }
    }
