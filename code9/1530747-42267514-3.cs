    public class Activity
    {
        public games _Games { get; set; }
        public sports _Sports { get; set; }
        public Activity()
        {
            this._Games = new games();
            this._Games.UpdatePlayerSub += _Games_UpdatePlayerSub;
            this._Sports = new sports();
        }
        private void _Games_UpdatePlayerSub()
        {
            if (_Sports != null)
            {
                _Sports.sub = 10;
            }
        }
    }
