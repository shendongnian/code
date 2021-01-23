    public class Gen : MonoBehaviour 
    {
        public Item[] Items = new Item[] { }; // Now Items has an array
        int iNum;
    
        void Awake()
        {  
            iNum = Items.Length; // iNum will in this case will be zero, because the array is empty.
        }
    }
