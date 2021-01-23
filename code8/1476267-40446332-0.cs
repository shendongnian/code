    public GameManager()
    {
        GameWorld = new EntityManager();
        GameSystems = new SystemManager();
        MainMap = new GameMap(61, 41);
    }
