    public abstract class Level
    {
        protected byte[,] byteArray;
        public Tile[,] tileArray;
        Sprite player = new Player();
        Sprite enemy = new Enemy();
        public Level()
        {
            CreateTileArray();
            tileArray = new Tile[byteArray.GetLength(0), byteArray.GetLength(1)];
            CreateWorld();
        }
        protected abstract void CreateTileArray();
        private void CreateWorld() {...}
        public void Draw(Surface showTiles) {...}
        public void Update() {
            player.Update();
            enemy.Update();
        }
    }
