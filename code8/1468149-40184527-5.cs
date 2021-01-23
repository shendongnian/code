    public interface IItem
    {
        // put things here that are common between Part and GameRoom
        int ID { get; }
    }
    public class GameRoom : IItem
    {
        public int ID { get; set; }
    }
    public class Player : IItem
    {
        public int ID { get; set; }
    }
    public interface IAbs
    {
        IItem GetItem(string guid);
    }
    public abstract class Abs<T> : IAbs
        where T : IItem
    {
        protected abstract T GetItem(string name);
        protected Abs(T item)
        {
            this.Item=item;
        }
        protected T Item { get; private set; }
        #region IAbs Members
        IItem IAbs.GetItem(string name)
        {
            return GetItem(name);
        }
        #endregion
    }
    public class GameRoomManager : Abs<GameRoom>
    {
        public GameRoomManager(GameRoom room) : base(room)
        {
        }
        protected override GameRoom GetItem(string guid)
        {
            return Item;
        }
        public GameRoom GetRoom(string guid) { return GetItem(guid); }
    }
    public class PlayerManager : Abs<Player>
    {
        public PlayerManager(Player player)
            : base(player)
        {
        }
        protected override Player GetItem(string guid)
        {
            return Item;
        }
        public Player GetPlayer(string guid) { return GetItem(guid); }
    }
