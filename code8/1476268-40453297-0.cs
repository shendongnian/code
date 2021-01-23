    public class GameManager
    {
        public static GameMap MainMap;
        public static EntityManager GameWorld;
        public static SystemManager GameSystems;
        static GameManager()
        {
            GameWorld = new EntityManager();
            GameSystems = new SystemManager();
            MainMap = new GameMap(61, 41);
        }
        //...
    }
