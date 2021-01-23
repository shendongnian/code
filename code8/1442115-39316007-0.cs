    public class GameItem {
        public string Type { get; private set; }
        GameItem(string type)
        {
            Type = type;
        }
    }
    public class SubGameItem : GameItem
    {
        public SubGameItem()
           : base(nameof(SubGameItem))
        {
        }
    } 
