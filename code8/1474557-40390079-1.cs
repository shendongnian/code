    public class Gen : MonoBehaviour
    {
        public Item[] Items { get; set; } = new Item[] { };
        int iNum = -1;
    
        public Gen()
        {
            iNum = Items.Length;
        }
    }
