    public interface IPart
    {
        // put things here that are common between Part and GameRoom
        int ID { get; }
    }
    public interface IAbs
    {
        IPart GetSomething(string name);
    }
    public class GameRoom : IPart
    {
        public int ID { get; set; }
    }
    public class GameRoomManager : IAbs
    {
        GameRoom part;
        #region IAbs Members
        public GameRoom GetSomething(string name)
        {
            return part;
        }
        IPart IAbs.GetSomething(string name)
        {
            return GetSomething(name);
        }
        #endregion
    }
    public class Player : IPart
    {
        public int ID { get; set; }
    }
    public class PlayerManager : IAbs
    {
        Player part;
        #region IAbs Members
        public Player GetSomething(string name)
        {
            return part;
        }
        IPart IAbs.GetSomething(string name)
        {
            return GetSomething(name);
        }
        #endregion
    }
