    public sealed class GamesList
    {
        public List<Game> Games { get; set; }
        public String Name { get; set; }
        private GamesList(String databaseName)
        {
            Name = databaseName;
        }
        public static Task<GamesList> Create(string databaseName)
        {
            GamesList instance = new GamesList(databaseName);
            instance.Games = await DataService.GetGames();
            return instance
        }
	    ...
    }
