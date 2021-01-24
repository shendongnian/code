    public abstract class Level {
        ...
        public void Update() {
            player.Update();
            player.CheckCollisionSurrounding(tileCollisionArray);
            enemy.Update();
            enemy.CheckCollisionSurrounding(tileCollisionArray);
        }
        ...
    }
