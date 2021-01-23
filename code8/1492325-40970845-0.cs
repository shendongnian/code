	public interface IFromSourceObjectMapper {
		void MapFromSourceObject(object source);	// TODO: Update parameter type
	}
	BaseViewModelFor<TSource> : BaseViewModel where TSource : class
	{
		public BaseViewModelFor(IAggregator aggregator, IRepository<TSource> repository, int i) 
		{
			Aggregator = aggregator;
			var source = repository.GetKey(i);
			var mapper = this as IFromSourceObjectMapper;
			if (mapper != null) {
				(this as CompanyEventsView).MapFromSourceObject(source); // (this as CompanyEventsView) how could I make this generic so if I inherit another class to point to it
			}
		}
	}
	CompanyEventsView : BaseViewModelFor<CompanyEvents>, IFromSourceObjectMapper
	{
		public void MapFromSourceObject(object source) { ... }
	}
