	public interface ISearchResult<out TAnimal> where TAnimal: IAnimal
	{
		TAnimal Pet { get; }
		decimal Price { get; }
	}
	public class SearchResult<TAnimal> : ISearchResult<TAnimal> where TAnimal : IAnimal
	{
		public TAnimal Pet { get; set; }
		public decimal Price { get; set; }
	}
    ...
	public ISearchResult<IAnimal> SearchForAPet(string query)
    {
        ...
    }
