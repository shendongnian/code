    /// <summary>
    /// Players held in cached and stored in database using Entity Framework
    /// </summary>
    public class SimplePlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbGeography Position { get; set; }
        [NotMapped]
        public string SerializedPosition
        {
            get { return Position.WellKnownValue.WellKnownText; }
            set
            {
                //-- This is crucial for the redundant updates in EF:
                if (value != Position.WellKnownValue.WellKnownText)
                {
                    Position = DbGeography.FromText(value);
                }
            }
        }
    }
    /// <summary>
    /// Get a player from the cache and only save
    /// it to the database if any property has changed
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public int UpdatePlayer(DbContext context)
    {
        Mapper.Initialize(cfg =>
        {
            cfg.CreateMap<SimplePlayer, SimplePlayer>().ForMember(m => m.Position, opt => opt.Ignore());
        });
        //-- Get the player from the cache
        var player = Game.Players.First();
        //-- When you un-comment this line, the result will be 1 
        //-- and the position will be changed in the database
        // player.Position = GeographyHelper.CreatePoint(11, 11);
        //-- Get the same player from the database
        var playerFromDb = context.Set<Player>().Find(player.ID);
            
        //-- Map the properties
        Mapper.Map(player, playerFromDb);
        //-- Save changes to the database if there are any
        int countChanges = context.SaveChanges();
        return countChanges;
    }
