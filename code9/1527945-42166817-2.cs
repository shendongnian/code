    public class InventoryAttempt : MonoBehaviour
    {
        public static Item JsonToItem(string filePath, int itemID)
        {
            string jsonString = File.ReadAllText(Application.dataPath + filePath);
            return JsonMapper.ToObject<List<Item>>(jsonString).First(x => x.Id);
        }
        void Start()
        {
            var item = JsonToItem("/Scripts/inventory.json", 1);
        }
    }
