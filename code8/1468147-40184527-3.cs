    public interface IPart
    {
        // put things here that are common between Part and GameRoom
        int ID { get; }
    }
    public interface IAbs
    {
        IPart GetSomething(string name);
    }
    public abstract class Abs<T> : IAbs
        where T : IPart
    {
        public abstract T GetSomething(string name);
        #region IAbs Members
        IPart IAbs.GetSomething(string name)
        {
            return GetSomething(name);
        }
        #endregion
    }
    public class GameRoom : IPart
    {
        public int ID { get; set; }
    }
    public class GameRoomManager : Abs<GameRoom>
    {
        GameRoom part;
        public override GameRoom GetSomething(string name)
        {
            return part;
        }
    }
    public class Player : IPart
    {
        public int ID { get; set; }
    }
    public class PlayerManager : Abs<Player>
    {
        Player part;
        public override Player GetSomething(string name)
        {
            return part;
        }
    }
