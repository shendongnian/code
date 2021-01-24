    public class GameListEntry : IComparable<GameListEntry>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int CompareTo(GameListEntry other)
        {
            if (Category == other.Category)
            {
                return 0;
            }
            if (Category == "Null / Empty")
            {
                return 1;
            }
            if (other.Category == "Null / Empty")
            {
                return -1;
            }
            return Category.CompareTo(other.Category);
        }
    }
    List<Game> games = ...;
    var listedGameEntries = games.SelectMany(x => x.Categories.Select(c => new GameListEntry { Name = x.Name, Category = string.IsNullOrEmpty(c) ? "Null / Empty" : c }));
    var groupedGames = listedGameEntries.GroupBy(x => x.Category);
