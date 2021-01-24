    [System.Serializable]
    public class Item
    {
        public string itemName;
        public string iconPath;
        public float price = 1f;
    
        [System.NonSerialized]
        public Sprite icon;
    
        public Item(string newItemName, Sprite newIcon, float newPrice)
        {
            this.itemName = newItemName;
            this.icon = newIcon;
            this.price = newPrice;
        }
    }
    
    // Use this for initialization
    void Start()
    {
        itemList = new List<Item>();
        TextAsset asset = Resources.Load(Path.Combine("Maps", "items")) as TextAsset;
        var items = JsonHelper.FromJson<Item>(asset.text);
        Debug.Log("" + items.Length);
        for (int i = 0; i < items.Length; i++)
        {
            itemList.Add(new Item(items[i].itemName, Resources.Load<Sprite>(items[i].iconPath), items[i].price));
        }
    }
