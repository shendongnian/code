    public class HomeViewModel
    {
        public FeaturedAlbum FeaturedAlbum { get; set; }
        public List<Song> TrendingSongs { get; set; }
        public List<AccountInfo> InspiredCreator { get; set; }
        public List<AccountInfoFavoriteCount> FavoriteCounts { get; set; } //Change this line
    }
    public class AccountInfoFavoriteCount
    {
        public int FavoriteCount { get; set; }
        public string CreatorID { get; set; }
    }
