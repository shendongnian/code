    public abstract class PlayerProxyBase : Player
    {
        protected readonly Player _player;
        public PlayerProxyBase(Player player)
        {
            _player = player;
        }
        public override void Run()
        {
            _player.Run();
        }
        public override string ToString()
        {
            return _player.ToString();
        }
    }
