    public interface ISearchResult<out TAnimal> where TAnimal : IAnimal
    {
        TAnimal Pet { get; }
        decimal Price { get; }
    }
