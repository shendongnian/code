    public class PlayersCollection : KeyedCollection<string, Players>
    {
        protected override string GetKeyForItem(Players item)
        {
            return item.PlayerName;
        }
    }
