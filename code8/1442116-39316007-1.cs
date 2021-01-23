    public class GameItem {
        public List<string> Type { get; private set; }
        GameItem(List<string> type)
        {
            Type = type;
            Type.Add(nameof(GameItem))
        }
        public IsType(string type)
        {
            return Type.Contains(type);
        }
    }
    public class SubGameItem : GameItem
    {
        public SubGameItem(List<string> type)
           : base(new List<string>(type){nameof(SubGameItem)})
        {
        }
    } 
