    public interface IRoom{
        string Name { get; set; }
        IList<IPlayer> Players { get; set; }
        // You can add players to the list with .Add(item) but maybe you want to validate the action or sth. like that.
        void AddPlayer(IPlayer player);
    }
