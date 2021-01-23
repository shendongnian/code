    public class Item : System.Object
    {
        public string name;
        public int Radius = 1;
        public GameObject obj;
    }
    
    public class Gen : MonoBehaviour {
        public Item[] Items;
        private int iNum { get { return Items.Length; /*add null check here to be safe*/ } } 
    }
