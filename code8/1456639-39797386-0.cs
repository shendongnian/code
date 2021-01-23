    class Program
    {
        static void Main()
        {
            List<Apple> top25FavApples = _appleService.FindFavorites(25);
            List<Sofa> top25FavSofas = _sofaService.FindFavorites(25);
            List<IFavoriteable> top25Total = top25FavApples.Concat<IFavoriteable>(top25FavSofas)
                                                           .OrderBy(x => x.FavoriteChangeDate)
                                                           .Take(25).ToList();
        }
    }
    public interface IFavoriteable
    {
        DateTime? FavoriteChangeDate { get; }
    }
    public class Apple : IFavoriteable
    {
        public DateTime? FavoriteChangeDate { get; set; }
        //...
    }
    public class Sofa : IFavoriteable
    {
        public DateTime? FavoriteChangeDate { get; set; }
        //...
    }
