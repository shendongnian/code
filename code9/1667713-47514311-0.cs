    class MessageDTO {
       //other properties
       public int FavouriteCount { get; set; }
       public bool IsFavorite => FavouriteCount > 0;
    }
