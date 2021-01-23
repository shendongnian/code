    public class Gen : MonoBehaviour
    {
        public Item[] Items { get; set; } = new Item[] { };
        int iNum = -1;
    
        //Awake is called once by Unity since Gen inherits from  MonoBehaviour
        public void Awake()
        {
            iNum = Items.Length;
        }
    }
