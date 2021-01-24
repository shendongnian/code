    public class MyPlayerProxy : PlayerProxyBase
    {
        public MyPlayerProxy(Player player)
            : base(player)
        { }
        public override string ToString()
        {
            return _player.Name;
        }
    }
