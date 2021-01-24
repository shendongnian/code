     public class Favorite
    {
        public Favorite()
        {
            FavoritesIds = new List<int>();
        }
        public int StudentId { get; set; }
        public List<int> FavoritesIds { get; set; }
        public int FavoriteId { get; set; }
    }
