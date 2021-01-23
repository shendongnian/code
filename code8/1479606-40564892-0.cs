    public class PlayersCollection : IEnumerable<Player>
    {
        private readonly IDictionary<string, Player> _players;
    
        public IEnumerator<Player> GetEnumerator()
        {
            return _players.Select(player => player.Value).GetEnumerator();
        }
    }
    
